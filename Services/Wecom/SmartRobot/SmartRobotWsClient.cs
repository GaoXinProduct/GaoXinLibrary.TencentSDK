using System.Buffers;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 智能机器人长连接 WebSocket 客户端实现
/// <para>
/// 通过 WebSocket 长连接与企业微信保持实时通信，无需公网 IP，无需消息加解密。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/>
/// </para>
/// </summary>
public sealed class SmartRobotWsClient : ISmartRobotWsClient
{
    private const int ChunkSize = 512 * 1024; // 512KB per chunk (before base64)
    private static readonly TimeSpan HeartbeatInterval = TimeSpan.FromSeconds(30);
    private static readonly TimeSpan ResponseTimeout = TimeSpan.FromSeconds(30);

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    private readonly WecomSmartBotOptions _options;
    private ClientWebSocket? _ws;
    private CancellationTokenSource? _receiveCts;
    private Task? _receiveTask;
    private Timer? _heartbeatTimer;
    private readonly SemaphoreSlim _sendLock = new(1, 1);
    private readonly ConcurrentDictionary<string, TaskCompletionSource<JsonElement>> _pendingRequests = new();
    private volatile bool _disposed;

    /// <inheritdoc/>
    public bool IsConnected => _ws?.State == WebSocketState.Open;

    /// <inheritdoc/>
    public event Action<string, WsMsgCallbackBody>? OnMsgCallback;

    /// <inheritdoc/>
    public event Action<string, WsEventCallbackBody>? OnEventCallback;

    /// <inheritdoc/>
    public event Action<string, DocToolCallInfo[]>? OnToolCallCallback;

    /// <inheritdoc/>
    public event Action<Exception?>? OnDisconnected;

    /// <summary>
    /// 使用企业微信智能机器人配置创建 WebSocket 客户端
    /// </summary>
    /// <param name="options">包含 BotId、BotSecret、BotWsUrl 的智能机器人配置</param>
    public SmartRobotWsClient(WecomSmartBotOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.BotId))
            throw new ArgumentException("WecomWebHookOptions.BotId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.BotSecret))
            throw new ArgumentException("WecomWebHookOptions.BotSecret 不能为空", nameof(options));

        _options = options;
    }

    // ─── 连接管理 ─────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task ConnectAsync(CancellationToken ct = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        if (IsConnected)
            return;

        // 清理旧连接
        await CleanupAsync().ConfigureAwait(false);

        _ws = new ClientWebSocket();
        _receiveCts = new CancellationTokenSource();

        await _ws.ConnectAsync(new Uri(_options.BotWsUrl), ct).ConfigureAwait(false);

        // 启动接收循环
        _receiveTask = ReceiveLoopAsync(_receiveCts.Token);

        // 发送 subscribe 指令
        var subscribeResponse = await SendRequestAsync<WsSubscribeBody, object>(
            WsCommands.Subscribe,
            new WsSubscribeBody { BotId = _options.BotId!, Secret = _options.BotSecret! },
            ct).ConfigureAwait(false);

        if (subscribeResponse.ErrCode != 0)
            throw new TencentException(subscribeResponse.ErrCode, subscribeResponse.ErrMsg ?? "subscribe failed", "企业微信");

        // 启动心跳定时器
        _heartbeatTimer = new Timer(_ => _ = PingAsync(), null, HeartbeatInterval, HeartbeatInterval);
    }

    // ─── 回复与主动推送 ───────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<WsResponse> RespondWelcomeMsgAsync(string reqId, WsRespondWelcomeMsgBody body, CancellationToken ct = default)
    {
        return await SendRequestWithReqIdAsync<WsRespondWelcomeMsgBody>(WsCommands.RespondWelcomeMsg, reqId, body, ct)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WsResponse> RespondMsgAsync(string reqId, WsRespondMsgBody body, CancellationToken ct = default)
    {
        return await SendRequestWithReqIdAsync<WsRespondMsgBody>(WsCommands.RespondMsg, reqId, body, ct)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WsResponse> RespondUpdateMsgAsync(string reqId, WsRespondUpdateMsgBody body, CancellationToken ct = default)
    {
        return await SendRequestWithReqIdAsync<WsRespondUpdateMsgBody>(WsCommands.RespondUpdateMsg, reqId, body, ct)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WsResponse> SendMsgAsync(WsSendMsgBody body, CancellationToken ct = default)
    {
        return await SendRequestAsync<WsSendMsgBody>(WsCommands.SendMsg, body, ct).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WsResponse> RespondToolResultAsync(string reqId, WsRespondToolResultBody body, CancellationToken ct = default)
    {
        return await SendRequestWithReqIdAsync<WsRespondToolResultBody>(WsCommands.RespondToolResult, reqId, body, ct)
            .ConfigureAwait(false);
    }

    // ─── 分片上传素材 ─────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<string> UploadMediaAsync(string type, string filename, ReadOnlyMemory<byte> data, string? md5 = null, CancellationToken ct = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        EnsureConnected();

        var totalSize = data.Length;
        var totalChunks = (int)Math.Ceiling((double)totalSize / ChunkSize);
        if (totalChunks > 100)
            throw new ArgumentException("文件过大，分片数量超过 100 片限制", nameof(data));

        // 1. 初始化上传
        var initResponse = await SendRequestAsync<WsUploadMediaInitBody, WsUploadMediaInitResponseBody>(
            WsCommands.UploadMediaInit,
            new WsUploadMediaInitBody
            {
                Type = type,
                Filename = filename,
                TotalSize = totalSize,
                TotalChunks = totalChunks,
                Md5 = md5
            },
            ct).ConfigureAwait(false);

        if (initResponse.ErrCode != 0)
            throw new TencentException(initResponse.ErrCode, initResponse.ErrMsg ?? "upload init failed", "企业微信");

        var uploadId = initResponse.Body!.UploadId;

        // 2. 逐片上传
        for (var i = 0; i < totalChunks; i++)
        {
            var offset = i * ChunkSize;
            var length = Math.Min(ChunkSize, totalSize - offset);
            var base64 = Convert.ToBase64String(data.Slice(offset, length).Span);

            var chunkResponse = await SendRequestAsync<WsUploadMediaChunkBody>(
                WsCommands.UploadMediaChunk,
                new WsUploadMediaChunkBody
                {
                    UploadId = uploadId,
                    ChunkIndex = i,
                    Base64Data = base64
                },
                ct).ConfigureAwait(false);

            if (chunkResponse.ErrCode != 0)
                throw new TencentException(chunkResponse.ErrCode, chunkResponse.ErrMsg ?? $"upload chunk {i} failed", "企业微信");
        }

        // 3. 完成上传
        var finishResponse = await SendRequestAsync<WsUploadMediaFinishBody, WsUploadMediaFinishResponseBody>(
            WsCommands.UploadMediaFinish,
            new WsUploadMediaFinishBody { UploadId = uploadId },
            ct).ConfigureAwait(false);

        if (finishResponse.ErrCode != 0)
            throw new TencentException(finishResponse.ErrCode, finishResponse.ErrMsg ?? "upload finish failed", "企业微信");

        return finishResponse.Body!.MediaId;
    }

    // ─── 心跳 ─────────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task PingAsync(CancellationToken ct = default)
    {
        if (_disposed || !IsConnected) return;

        try
        {
            var request = new WsRequest<object>
            {
                Cmd = WsCommands.Ping,
                Headers = new WsHeaders { ReqId = Guid.NewGuid().ToString("N") }
            };
            await SendFrameAsync(request, ct).ConfigureAwait(false);
        }
        catch
        {
            // 心跳失败不抛异常，由接收循环检测断连
        }
    }

    // ─── 内部发送方法 ─────────────────────────────────────────────────────

    private async Task<WsResponse> SendRequestAsync<TBody>(string cmd, TBody body, CancellationToken ct)
    {
        var resp = await SendRequestAsync<TBody, object>(cmd, body, ct).ConfigureAwait(false);
        return resp;
    }

    private async Task<WsResponse> SendRequestWithReqIdAsync<TBody>(string cmd, string reqId, TBody body, CancellationToken ct)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        EnsureConnected();

        var request = new WsRequest<TBody>
        {
            Cmd = cmd,
            Headers = new WsHeaders { ReqId = reqId },
            Body = body
        };

        var tcs = new TaskCompletionSource<JsonElement>(TaskCreationOptions.RunContinuationsAsynchronously);
        _pendingRequests[reqId] = tcs;

        try
        {
            await SendFrameAsync(request, ct).ConfigureAwait(false);

            using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            timeoutCts.CancelAfter(ResponseTimeout);
            var registration = timeoutCts.Token.Register(() => tcs.TrySetCanceled(timeoutCts.Token));

            try
            {
                var responseElement = await tcs.Task.ConfigureAwait(false);
                return responseElement.Deserialize<WsResponse>(JsonOptions) ?? new WsResponse { ErrCode = -1, ErrMsg = "deserialization failed" };
            }
            finally
            {
                await registration.DisposeAsync().ConfigureAwait(false);
            }
        }
        finally
        {
            _pendingRequests.TryRemove(reqId, out _);
        }
    }

    private async Task<WsResponse<TResp>> SendRequestAsync<TBody, TResp>(string cmd, TBody body, CancellationToken ct)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        EnsureConnected();

        var reqId = Guid.NewGuid().ToString("N");
        var request = new WsRequest<TBody>
        {
            Cmd = cmd,
            Headers = new WsHeaders { ReqId = reqId },
            Body = body
        };

        var tcs = new TaskCompletionSource<JsonElement>(TaskCreationOptions.RunContinuationsAsynchronously);
        _pendingRequests[reqId] = tcs;

        try
        {
            await SendFrameAsync(request, ct).ConfigureAwait(false);

            using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            timeoutCts.CancelAfter(ResponseTimeout);
            var registration = timeoutCts.Token.Register(() => tcs.TrySetCanceled(timeoutCts.Token));

            try
            {
                var responseElement = await tcs.Task.ConfigureAwait(false);
                return responseElement.Deserialize<WsResponse<TResp>>(JsonOptions)
                    ?? new WsResponse<TResp> { ErrCode = -1, ErrMsg = "deserialization failed" };
            }
            finally
            {
                await registration.DisposeAsync().ConfigureAwait(false);
            }
        }
        finally
        {
            _pendingRequests.TryRemove(reqId, out _);
        }
    }

    private async Task SendFrameAsync<T>(WsRequest<T> frame, CancellationToken ct)
    {
        var json = JsonSerializer.SerializeToUtf8Bytes(frame, JsonOptions);
        await _sendLock.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            await _ws!.SendAsync(json.AsMemory(), WebSocketMessageType.Text, true, ct).ConfigureAwait(false);
        }
        finally
        {
            _sendLock.Release();
        }
    }

    // ─── 接收循环 ─────────────────────────────────────────────────────────

    private async Task ReceiveLoopAsync(CancellationToken ct)
    {
        var buffer = new byte[8192];
        using var ms = new MemoryStream();

        try
        {
            while (!ct.IsCancellationRequested && _ws?.State == WebSocketState.Open)
            {
                ms.SetLength(0);
                ValueWebSocketReceiveResult result;
                do
                {
                    result = await _ws.ReceiveAsync(buffer.AsMemory(), ct).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        OnDisconnected?.Invoke(null);
                        return;
                    }
                    ms.Write(buffer, 0, result.Count);
                } while (!result.EndOfMessage);

                if (result.MessageType != WebSocketMessageType.Text)
                    continue;

                try
                {
                    var doc = JsonDocument.Parse(ms.ToArray());
                    var root = doc.RootElement;
                    DispatchFrame(root);
                }
                catch
                {
                    // 无法解析的消息静默忽略
                }
            }
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            // 正常取消
        }
        catch (WebSocketException ex)
        {
            OnDisconnected?.Invoke(ex);
        }
        catch (Exception ex)
        {
            OnDisconnected?.Invoke(ex);
        }
    }

    private void DispatchFrame(JsonElement root)
    {
        var cmd = root.TryGetProperty("cmd", out var cmdElem) ? cmdElem.GetString() : null;

        // 服务端推送的回调（带 cmd）
        if (cmd == WsCommands.MsgCallback)
        {
            var reqId = GetReqId(root);
            if (root.TryGetProperty("body", out var bodyElem))
            {
                var body = bodyElem.Deserialize<WsMsgCallbackBody>(JsonOptions);
                if (body is not null)
                {
                    // 文档工具调用：msgtype 为 tool_calls 或 body 中包含 tool_calls 数组
                    if (body.ToolCalls is { Length: > 0 })
                        OnToolCallCallback?.Invoke(reqId, body.ToolCalls);

                    OnMsgCallback?.Invoke(reqId, body);
                }
            }
            return;
        }

        if (cmd == WsCommands.EventCallback)
        {
            var reqId = GetReqId(root);
            if (root.TryGetProperty("body", out var bodyElem))
            {
                var body = bodyElem.Deserialize<WsEventCallbackBody>(JsonOptions);
                if (body is not null)
                    OnEventCallback?.Invoke(reqId, body);
            }
            return;
        }

        if (cmd == WsCommands.Pong)
        {
            // 心跳应答，不处理
            return;
        }

        // 响应帧：通过 req_id 路由到等待中的请求
        var respReqId = GetReqId(root);
        if (!string.IsNullOrEmpty(respReqId) && _pendingRequests.TryRemove(respReqId, out var tcs))
        {
            tcs.TrySetResult(root.Clone());
        }
    }

    private static string GetReqId(JsonElement root)
    {
        if (root.TryGetProperty("headers", out var headers) &&
            headers.TryGetProperty("req_id", out var reqIdElem))
        {
            return reqIdElem.GetString() ?? string.Empty;
        }
        return string.Empty;
    }

    // ─── 辅助 ─────────────────────────────────────────────────────────────

    private void EnsureConnected()
    {
        if (!IsConnected)
            throw new InvalidOperationException("WebSocket 未连接，请先调用 ConnectAsync");
    }

    private async Task CleanupAsync()
    {
        _heartbeatTimer?.Dispose();
        _heartbeatTimer = null;

        _receiveCts?.Cancel();

        if (_ws is not null)
        {
            if (_ws.State == WebSocketState.Open)
            {
                try
                {
                    await _ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "dispose", CancellationToken.None)
                        .ConfigureAwait(false);
                }
                catch
                {
                    // 忽略关闭时的异常
                }
            }
            _ws.Dispose();
            _ws = null;
        }

        if (_receiveTask is not null)
        {
            try { await _receiveTask.ConfigureAwait(false); }
            catch { /* ignore */ }
            _receiveTask = null;
        }

        _receiveCts?.Dispose();
        _receiveCts = null;

        // 取消所有等待中的请求
        foreach (var kvp in _pendingRequests)
        {
            kvp.Value.TrySetCanceled();
        }
        _pendingRequests.Clear();
    }

    // ─── IAsyncDisposable ─────────────────────────────────────────────────

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;
        _disposed = true;

        await CleanupAsync().ConfigureAwait(false);
        _sendLock.Dispose();
    }
}

using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 智能机器人长连接 WebSocket 客户端接口
/// <para>
/// 通过 WebSocket 长连接与企业微信保持实时通信，无需公网 IP，无需消息加解密。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/>
/// </para>
/// </summary>
public interface ISmartRobotWsClient : IAsyncDisposable
{
    /// <summary>当前连接是否已建立</summary>
    bool IsConnected { get; }

    /// <summary>
    /// 收到消息回调时触发
    /// <para>参数：(reqId, body)</para>
    /// </summary>
    event Action<string, WsMsgCallbackBody>? OnMsgCallback;

    /// <summary>
    /// 收到事件回调时触发
    /// <para>参数：(reqId, body)</para>
    /// </summary>
    event Action<string, WsEventCallbackBody>? OnEventCallback;

    /// <summary>
    /// 收到文档工具调用回调时触发
    /// <para>
    /// 当消息回调中 msgtype 为 tool_calls 时，解析工具调用列表并触发此事件。
    /// 参数：(reqId, toolCalls)
    /// </para>
    /// </summary>
    event Action<string, DocToolCallInfo[]>? OnToolCallCallback;

    /// <summary>连接断开时触发</summary>
    event Action<Exception?>? OnDisconnected;

    /// <summary>
    /// 建立 WebSocket 连接并完成订阅（aibot_subscribe）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task ConnectAsync(CancellationToken ct = default);

    /// <summary>
    /// 回复欢迎语（收到 enter_chat 事件后 5 秒内调用）
    /// </summary>
    /// <param name="reqId">透传事件回调中的 req_id</param>
    /// <param name="body">消息体</param>
    /// <param name="ct">取消令牌</param>
    Task<WsResponse> RespondWelcomeMsgAsync(string reqId, WsRespondWelcomeMsgBody body, CancellationToken ct = default);

    /// <summary>
    /// 回复消息（支持流式，收到 aibot_msg_callback 后 24 小时内调用）
    /// </summary>
    /// <param name="reqId">透传消息回调中的 req_id</param>
    /// <param name="body">消息体</param>
    /// <param name="ct">取消令牌</param>
    Task<WsResponse> RespondMsgAsync(string reqId, WsRespondMsgBody body, CancellationToken ct = default);

    /// <summary>
    /// 更新模板卡片（收到 template_card_event 后 5 秒内调用）
    /// </summary>
    /// <param name="reqId">透传事件回调中的 req_id</param>
    /// <param name="body">消息体</param>
    /// <param name="ct">取消令牌</param>
    Task<WsResponse> RespondUpdateMsgAsync(string reqId, WsRespondUpdateMsgBody body, CancellationToken ct = default);

    /// <summary>
    /// 主动推送消息（无需回调触发，限 30 条/分钟、1000 条/小时）
    /// </summary>
    /// <param name="body">消息体</param>
    /// <param name="ct">取消令牌</param>
    Task<WsResponse> SendMsgAsync(WsSendMsgBody body, CancellationToken ct = default);

    /// <summary>
    /// 通过分片方式上传临时素材
    /// </summary>
    /// <param name="type">文件类型（file / image / voice / video）</param>
    /// <param name="filename">文件名</param>
    /// <param name="data">文件数据</param>
    /// <param name="md5">文件 MD5（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>上传成功后的 media_id</returns>
    Task<string> UploadMediaAsync(string type, string filename, ReadOnlyMemory<byte> data, string? md5 = null, CancellationToken ct = default);

    /// <summary>
    /// 发送心跳 ping
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task PingAsync(CancellationToken ct = default);

    /// <summary>
    /// 回传文档工具调用结果
    /// <para>
    /// 收到文档工具调用（<see cref="OnToolCallCallback"/>）后，执行工具操作并将结果回传。
    /// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101468"/>
    /// </para>
    /// </summary>
    /// <param name="reqId">透传消息回调中的 req_id</param>
    /// <param name="body">工具调用结果消息体</param>
    /// <param name="ct">取消令牌</param>
    Task<WsResponse> RespondToolResultAsync(string reqId, WsRespondToolResultBody body, CancellationToken ct = default);
}

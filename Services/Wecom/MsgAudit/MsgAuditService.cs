using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core.Finance;
using GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会话内容存档服务实现</summary>
public class MsgAuditService : IMsgAuditService
{
    private readonly WecomHttpClient _http;
    private readonly string _privateKey;
    private FinanceSdk? _financeSdk;
    private readonly object _sdkLock = new();
    private readonly string _corpId;
    private readonly string? _msgAuditSecret;
    private bool _disposed;

    public MsgAuditService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;
        _corpId = options.CorpId;
        _msgAuditSecret = options.MsgAuditSecret;
        _privateKey = options.MsgAuditPrivateKey ?? string.Empty;
    }

    // ─── HTTP 管理接口 ────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<string[]> GetPermitUserListAsync(int? type = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetPermitUserListResponse>(
            "/cgi-bin/msgaudit/get_permit_user_list",
            new GetPermitUserListRequest { Type = type }, ct);
        return resp.Ids ?? [];
    }

    /// <inheritdoc/>
    public async Task<AgreeInfo[]> CheckSingleAgreeAsync(CheckAgreeItem[] info, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CheckAgreeResponse>(
            "/cgi-bin/msgaudit/check_single_agree",
            new CheckAgreeRequest { Info = info }, ct);
        return resp.AgreeInfoList ?? [];
    }

    /// <inheritdoc/>
    public async Task<AgreeInfo[]> CheckRoomAgreeAsync(string roomId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CheckRoomAgreeResponse>(
            "/cgi-bin/msgaudit/check_room_agree",
            new CheckRoomAgreeRequest { RoomId = roomId }, ct);
        return resp.AgreeInfoList ?? [];
    }

    /// <inheritdoc/>
    public async Task<MsgAuditGroupChatGetResponse> GetGroupChatAsync(string roomId, CancellationToken ct = default)
    {
        return await _http.PostAsync<MsgAuditGroupChatGetResponse>(
            "/cgi-bin/msgaudit/groupchat/get",
            new MsgAuditGroupChatGetRequest { RoomId = roomId }, ct);
    }

    // ─── 原生 SDK 接口 ────────────────────────────────────────────────

    /// <inheritdoc/>
    public ChatDataItem[] GetChatData(ulong seq, uint limit = 1000, string proxy = "", string passwd = "", int timeout = 5)
    {
        var sdk = EnsureSdk();
        var json = sdk.GetChatData(seq, limit, proxy, passwd, timeout);
        var result = System.Text.Json.JsonSerializer.Deserialize<ChatDataListResult>(json, WecomHttpClient.JsonOptions);
        if (result is null || result.ErrCode != 0)
            throw new TencentException(result?.ErrCode ?? -1, result?.ErrMsg ?? "拉取会话记录返回为空", "企业微信");

        return result.ChatData ?? [];
    }

    /// <inheritdoc/>
    public string DecryptChatMessage(string encryptRandomKey, string encryptChatMsg)
    {
        if (string.IsNullOrWhiteSpace(_privateKey))
            throw new TencentException("未配置 MsgAuditPrivateKey，无法解密会话消息");

        // 内部完成：1) RSA 解密 encrypt_random_key  2) 调用原生 SDK 解密消息内容
        return FinanceSdk.DecryptChatMessage(_privateKey, encryptRandomKey, encryptChatMsg);
    }

    /// <inheritdoc/>
    public byte[] GetMediaData(string sdkFileId, string proxy = "", string passwd = "", int timeout = 5)
    {
        var sdk = EnsureSdk();
        return sdk.GetMediaData(sdkFileId, proxy, passwd, timeout);
    }

    /// <inheritdoc/>
    public void GetMediaData(string sdkFileId, Stream destination, string proxy = "", string passwd = "", int timeout = 5)
    {
        var sdk = EnsureSdk();
        sdk.GetMediaData(sdkFileId, destination, proxy, passwd, timeout);
    }

    private FinanceSdk EnsureSdk()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        if (string.IsNullOrWhiteSpace(_msgAuditSecret))
            throw new TencentException("未配置 MsgAuditSecret，无法使用会话内容存档原生 SDK 功能");

        if (_financeSdk is not null)
            return _financeSdk;

        lock (_sdkLock)
        {
            return _financeSdk ??= new FinanceSdk(_corpId, _msgAuditSecret);
        }
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _financeSdk?.Dispose();
        _financeSdk = null;
    }
}

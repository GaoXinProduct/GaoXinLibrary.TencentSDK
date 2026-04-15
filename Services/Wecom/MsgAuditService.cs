using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core.Finance;
using GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会话内容存档服务实现</summary>
public class MsgAuditService
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

    #region HTTP 管理接口

    /// <summary>
    /// 获取会话内容存档开启成员列表
    /// </summary>
    /// <param name="type">成员类型：0-全部 1-仅内部 2-仅外部（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>开启会话内容存档的成员 userid 列表</returns>
    public async Task<string[]> GetPermitUserListAsync(int? type = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetPermitUserListResponse>(
            "/cgi-bin/msgaudit/get_permit_user_list",
            new GetPermitUserListRequest { Type = type }, ct);
        return resp.Ids ?? [];
    }

    /// <summary>
    /// 获取会话同意情况（单聊）
    /// </summary>
    /// <param name="info">待查询的会话信息列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>同意情况列表</returns>
    public async Task<AgreeInfo[]> CheckSingleAgreeAsync(CheckAgreeItem[] info, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CheckAgreeResponse>(
            "/cgi-bin/msgaudit/check_single_agree",
            new CheckAgreeRequest { Info = info }, ct);
        return resp.AgreeInfoList ?? [];
    }

    /// <summary>
    /// 获取会话同意情况（群聊）
    /// </summary>
    /// <param name="roomId">待查询的群 roomid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>同意情况列表</returns>
    public async Task<AgreeInfo[]> CheckRoomAgreeAsync(string roomId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CheckRoomAgreeResponse>(
            "/cgi-bin/msgaudit/check_room_agree",
            new CheckRoomAgreeRequest { RoomId = roomId }, ct);
        return resp.AgreeInfoList ?? [];
    }

    /// <summary>
    /// 获取会话内容存档内部群信息
    /// </summary>
    /// <param name="roomId">待查询的群 roomid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>群信息</returns>
    public async Task<MsgAuditGroupChatGetResponse> GetGroupChatAsync(string roomId, CancellationToken ct = default)
    {
        return await _http.PostAsync<MsgAuditGroupChatGetResponse>(
            "/cgi-bin/msgaudit/groupchat/get",
            new MsgAuditGroupChatGetRequest { RoomId = roomId }, ct);
    }

    #endregion
    #region 原生 SDK 接口

    /// <summary>
    /// 拉取会话记录数据（通过原生 C SDK）
    /// <para>需要先在 <see cref="WecomOptions"/> 中配置 <c>MsgAuditSecret</c> 和 <c>MsgAuditPrivateKey</c>。</para>
    /// </summary>
    /// <param name="seq">从指定的 seq 开始拉取消息（返回 seq+1 开始的消息），首次传 0</param>
    /// <param name="limit">一次拉取的数量上限，最大 1000</param>
    /// <param name="proxy">代理地址（如 socks5://ip:port），不使用代理传空字符串</param>
    /// <param name="passwd">代理密码，不使用代理传空字符串</param>
    /// <param name="timeout">超时时间（秒），建议 5</param>
    /// <returns>会话记录列表（加密状态）</returns>
    public ChatDataItem[] GetChatData(ulong seq, uint limit = 1000, string proxy = "", string passwd = "", int timeout = 5)
    {
        var sdk = EnsureSdk();
        var json = sdk.GetChatData(seq, limit, proxy, passwd, timeout);
        var result = System.Text.Json.JsonSerializer.Deserialize<ChatDataListResult>(json, WecomHttpClient.JsonOptions);
        if (result is null || result.ErrCode != 0)
            throw new TencentException(result?.ErrCode ?? -1, result?.ErrMsg ?? "拉取会话记录返回为空", "企业微信");

        return result.ChatData ?? [];
    }

    /// <summary>
    /// 解密单条会话消息
    /// </summary>
    /// <param name="encryptRandomKey">消息中的 encrypt_random_key</param>
    /// <param name="encryptChatMsg">消息中的 encrypt_chat_msg</param>
    /// <returns>解密后的消息明文</returns>
    public string DecryptChatMessage(string encryptRandomKey, string encryptChatMsg)
    {
        if (string.IsNullOrWhiteSpace(_privateKey))
            throw new TencentException("未配置 MsgAuditPrivateKey，无法解密会话消息");

        // 内部完成：1) RSA 解密 encrypt_random_key  2) 调用原生 SDK 解密消息内容
        return FinanceSdk.DecryptChatMessage(_privateKey, encryptRandomKey, encryptChatMsg);
    }

    /// <summary>
    /// 下载媒体文件数据（通过原生 C SDK）
    /// </summary>
    /// <param name="sdkFileId">消息中的 sdkfileid</param>
    /// <param name="proxy">代理地址</param>
    /// <param name="passwd">代理密码</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <returns>媒体文件字节数据</returns>
    public byte[] GetMediaData(string sdkFileId, string proxy = "", string passwd = "", int timeout = 5)
    {
        var sdk = EnsureSdk();
        return sdk.GetMediaData(sdkFileId, proxy, passwd, timeout);
    }

    /// <summary>
    /// 下载媒体文件数据（通过原生 C SDK）
    /// </summary>
    /// <param name="sdkFileId">消息中的 sdkfileid</param>
    /// <param name="proxy">代理地址</param>
    /// <param name="passwd">代理密码</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <returns>媒体文件字节数据</returns>
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
    #endregion
}

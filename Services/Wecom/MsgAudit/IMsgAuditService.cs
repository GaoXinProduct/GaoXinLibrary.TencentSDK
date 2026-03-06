using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core.Finance;
using GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 会话内容存档服务接口
/// <para>
/// 提供会话内容存档的管理类 HTTP 接口（开启成员列表、会话同意情况、群信息），
/// 以及基于企业微信原生 C SDK 的消息拉取、解密和媒体文件下载功能。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/91360"/>
/// </para>
/// </summary>
public interface IMsgAuditService : IDisposable
{
    // ─── HTTP 管理接口 ────────────────────────────────────────────────

    /// <summary>
    /// 获取会话内容存档开启成员列表
    /// </summary>
    /// <param name="type">成员类型：0-全部 1-仅内部 2-仅外部（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>开启会话内容存档的成员 userid 列表</returns>
    Task<string[]> GetPermitUserListAsync(int? type = null, CancellationToken ct = default);

    /// <summary>
    /// 获取会话同意情况（单聊）
    /// </summary>
    /// <param name="info">待查询的会话信息列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>同意情况列表</returns>
    Task<AgreeInfo[]> CheckSingleAgreeAsync(CheckAgreeItem[] info, CancellationToken ct = default);

    /// <summary>
    /// 获取会话同意情况（群聊）
    /// </summary>
    /// <param name="roomId">待查询的群 roomid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>同意情况列表</returns>
    Task<AgreeInfo[]> CheckRoomAgreeAsync(string roomId, CancellationToken ct = default);

    /// <summary>
    /// 获取会话内容存档内部群信息
    /// </summary>
    /// <param name="roomId">待查询的群 roomid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>群信息</returns>
    Task<MsgAuditGroupChatGetResponse> GetGroupChatAsync(string roomId, CancellationToken ct = default);

    // ─── 原生 SDK 接口 ────────────────────────────────────────────────

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
    ChatDataItem[] GetChatData(ulong seq, uint limit = 1000, string proxy = "", string passwd = "", int timeout = 5);

    /// <summary>
    /// 解密单条会话消息
    /// </summary>
    /// <param name="encryptRandomKey">消息中的 encrypt_random_key</param>
    /// <param name="encryptChatMsg">消息中的 encrypt_chat_msg</param>
    /// <returns>解密后的消息明文</returns>
    string DecryptChatMessage(string encryptRandomKey, string encryptChatMsg);

    /// <summary>
    /// 下载媒体文件数据（通过原生 C SDK）
    /// </summary>
    /// <param name="sdkFileId">消息中的 sdkfileid</param>
    /// <param name="proxy">代理地址</param>
    /// <param name="passwd">代理密码</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <returns>媒体文件字节数据</returns>
    byte[] GetMediaData(string sdkFileId, string proxy = "", string passwd = "", int timeout = 5);

    /// <summary>
    /// 下载媒体文件并写入流（适用于大文件，避免一次性加载到内存）
    /// </summary>
    /// <param name="sdkFileId">消息中的 sdkfileid</param>
    /// <param name="destination">目标输出流</param>
    /// <param name="proxy">代理地址</param>
    /// <param name="passwd">代理密码</param>
    /// <param name="timeout">超时时间（秒）</param>
    void GetMediaData(string sdkFileId, Stream destination, string proxy = "", string passwd = "", int timeout = 5);
}

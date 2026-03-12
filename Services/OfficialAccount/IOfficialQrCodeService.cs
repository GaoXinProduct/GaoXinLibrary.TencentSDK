using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 公众号服务号二维码服务接口
/// </summary>
public interface IOfficialQrCodeService
{
    /// <summary>
    /// 创建临时二维码（数字场景值）
    /// </summary>
    /// <param name="sceneId">场景值 ID（1~2^31-1）</param>
    /// <param name="expireSeconds">有效期（秒），最大 2592000（30 天）</param>
    /// <param name="ct">取消令牌</param>
    Task<CreateQrCodeResponse> CreateTemporaryAsync(int sceneId, int expireSeconds = 2592000, CancellationToken ct = default);

    /// <summary>
    /// 创建临时二维码（字符串场景值）
    /// </summary>
    /// <param name="sceneStr">场景值（长度不超过 64）</param>
    /// <param name="expireSeconds">有效期（秒），最大 2592000（30 天）</param>
    /// <param name="ct">取消令牌</param>
    Task<CreateQrCodeResponse> CreateTemporaryAsync(string sceneStr, int expireSeconds = 2592000, CancellationToken ct = default);

    /// <summary>
    /// 创建永久二维码（数字场景值）
    /// </summary>
    /// <param name="sceneId">场景值 ID（1~100000）</param>
    /// <param name="ct">取消令牌</param>
    Task<CreateQrCodeResponse> CreatePermanentAsync(int sceneId, CancellationToken ct = default);

    /// <summary>
    /// 创建永久二维码（字符串场景值）
    /// </summary>
    /// <param name="sceneStr">场景值（长度不超过 64）</param>
    /// <param name="ct">取消令牌</param>
    Task<CreateQrCodeResponse> CreatePermanentAsync(string sceneStr, CancellationToken ct = default);

    /// <summary>
    /// 构建通过 ticket 拉取二维码图片的 URL
    /// </summary>
    /// <param name="ticket">二维码 ticket</param>
    /// <returns>二维码图片 URL</returns>
    string BuildShowUrl(string ticket);

    /// <summary>
    /// 增加或修改二维码规则（扫码打开小程序）
    /// </summary>
    Task<WechatBaseResponse> AddOrUpdateJumpRuleAsync(QrcodeJumpAddRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取已设置的二维码规则
    /// </summary>
    Task<QrcodeJumpGetResponse> GetJumpRulesAsync(QrcodeJumpGetRequest request, CancellationToken ct = default);

    /// <summary>
    /// 发布已设置的二维码规则
    /// </summary>
    Task<WechatBaseResponse> PublishJumpRuleAsync(QrcodeJumpPublishRequest request, CancellationToken ct = default);

    /// <summary>
    /// 删除已设置的二维码规则
    /// </summary>
    Task<WechatBaseResponse> DeleteJumpRuleAsync(QrcodeJumpDeleteRequest request, CancellationToken ct = default);

    /// <summary>
    /// 长信息转短链
    /// </summary>
    Task<ShortLinkGenerateResponse> GenerateShortLinkAsync(ShortLinkGenerateRequest request, CancellationToken ct = default);

    /// <summary>
    /// 短链转长信息
    /// </summary>
    Task<ShortLinkFetchResponse> FetchShortLinkAsync(ShortLinkFetchRequest request, CancellationToken ct = default);
}

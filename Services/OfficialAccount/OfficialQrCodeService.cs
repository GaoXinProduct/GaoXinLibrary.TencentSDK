using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 公众号服务号二维码服务实现
/// </summary>
public class OfficialQrCodeService
{
    private readonly WechatHttpClient _http;

    public OfficialQrCodeService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 创建临时二维码（数字场景值）
    /// </summary>
    /// <param name="sceneId">场景值 ID（1~2^31-1）</param>
    /// <param name="expireSeconds">有效期（秒），最大 2592000（30 天）</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateQrCodeResponse> CreateTemporaryAsync(int sceneId, int expireSeconds = 2592000, CancellationToken ct = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(sceneId, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(expireSeconds, 1);

        var payload = new
        {
            expire_seconds = Math.Min(expireSeconds, 2592000),
            action_name = "QR_SCENE",
            action_info = new
            {
                scene = new
                {
                    scene_id = sceneId
                }
            }
        };

        return _http.PostAsync<CreateQrCodeResponse>("/cgi-bin/qrcode/create", payload, ct);
    }

    /// <summary>
    /// 创建临时二维码（数字场景值）
    /// </summary>
    /// <param name="sceneId">场景值 ID（1~2^31-1）</param>
    /// <param name="expireSeconds">有效期（秒），最大 2592000（30 天）</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateQrCodeResponse> CreateTemporaryAsync(string sceneStr, int expireSeconds = 2592000, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sceneStr);
        ArgumentOutOfRangeException.ThrowIfLessThan(expireSeconds, 1);

        var payload = new
        {
            expire_seconds = Math.Min(expireSeconds, 2592000),
            action_name = "QR_STR_SCENE",
            action_info = new
            {
                scene = new
                {
                    scene_str = sceneStr
                }
            }
        };

        return _http.PostAsync<CreateQrCodeResponse>("/cgi-bin/qrcode/create", payload, ct);
    }

    /// <summary>
    /// 创建永久二维码（数字场景值）
    /// </summary>
    /// <param name="sceneId">场景值 ID（1~100000）</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateQrCodeResponse> CreatePermanentAsync(int sceneId, CancellationToken ct = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(sceneId, 1);

        var payload = new
        {
            action_name = "QR_LIMIT_SCENE",
            action_info = new
            {
                scene = new
                {
                    scene_id = sceneId
                }
            }
        };

        return _http.PostAsync<CreateQrCodeResponse>("/cgi-bin/qrcode/create", payload, ct);
    }

    /// <summary>
    /// 创建永久二维码（数字场景值）
    /// </summary>
    /// <param name="sceneId">场景值 ID（1~100000）</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateQrCodeResponse> CreatePermanentAsync(string sceneStr, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sceneStr);

        var payload = new
        {
            action_name = "QR_LIMIT_STR_SCENE",
            action_info = new
            {
                scene = new
                {
                    scene_str = sceneStr
                }
            }
        };

        return _http.PostAsync<CreateQrCodeResponse>("/cgi-bin/qrcode/create", payload, ct);
    }

    /// <summary>
    /// 构建通过 ticket 拉取二维码图片的 URL
    /// </summary>
    /// <param name="ticket">二维码 ticket</param>
    /// <returns>二维码图片 URL</returns>
    public string BuildShowUrl(string ticket)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ticket);
        return $"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={Uri.EscapeDataString(ticket)}";
    }

    /// <summary>
    /// 增加或修改二维码规则（扫码打开小程序）
    /// </summary>
    public Task<WechatBaseResponse> AddOrUpdateJumpRuleAsync(QrcodeJumpAddRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/wxopen/qrcodejumpadd", request, ct);

    /// <summary>
    /// 获取已设置的二维码规则
    /// </summary>
    public Task<QrcodeJumpGetResponse> GetJumpRulesAsync(QrcodeJumpGetRequest request, CancellationToken ct = default)
        => _http.PostAsync<QrcodeJumpGetResponse>("/cgi-bin/wxopen/qrcodejumpget", request, ct);

    /// <summary>
    /// 发布已设置的二维码规则
    /// </summary>
    public Task<WechatBaseResponse> PublishJumpRuleAsync(QrcodeJumpPublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/wxopen/qrcodejumppublish", request, ct);

    /// <summary>
    /// 删除已设置的二维码规则
    /// </summary>
    public Task<WechatBaseResponse> DeleteJumpRuleAsync(QrcodeJumpDeleteRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/wxopen/qrcodejumpdelete", request, ct);

    /// <summary>
    /// 长信息转短链
    /// </summary>
    public Task<ShortLinkGenerateResponse> GenerateShortLinkAsync(ShortLinkGenerateRequest request, CancellationToken ct = default)
        => _http.PostAsync<ShortLinkGenerateResponse>("/cgi-bin/shorten/gen", request, ct);

    /// <summary>
    /// 短链转长信息
    /// </summary>
    public Task<ShortLinkFetchResponse> FetchShortLinkAsync(ShortLinkFetchRequest request, CancellationToken ct = default)
        => _http.PostAsync<ShortLinkFetchResponse>("/cgi-bin/shorten/fetch", request, ct);
}

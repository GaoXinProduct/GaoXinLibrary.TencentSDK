using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 公众号服务号二维码服务实现
/// </summary>
public class OfficialQrCodeService : IOfficialQrCodeService
{
    private readonly WechatHttpClient _http;

    public OfficialQrCodeService(WechatHttpClient http)
    {
        _http = http;
    }

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

    public string BuildShowUrl(string ticket)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ticket);
        return $"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={Uri.EscapeDataString(ticket)}";
    }

    public Task<WechatBaseResponse> AddOrUpdateJumpRuleAsync(QrcodeJumpAddRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/wxopen/qrcodejumpadd", request, ct);

    public Task<QrcodeJumpGetResponse> GetJumpRulesAsync(QrcodeJumpGetRequest request, CancellationToken ct = default)
        => _http.PostAsync<QrcodeJumpGetResponse>("/cgi-bin/wxopen/qrcodejumpget", request, ct);

    public Task<WechatBaseResponse> PublishJumpRuleAsync(QrcodeJumpPublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/wxopen/qrcodejumppublish", request, ct);

    public Task<WechatBaseResponse> DeleteJumpRuleAsync(QrcodeJumpDeleteRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/wxopen/qrcodejumpdelete", request, ct);

    public Task<ShortLinkGenerateResponse> GenerateShortLinkAsync(ShortLinkGenerateRequest request, CancellationToken ct = default)
        => _http.PostAsync<ShortLinkGenerateResponse>("/cgi-bin/shorten/gen", request, ct);

    public Task<ShortLinkFetchResponse> FetchShortLinkAsync(ShortLinkFetchRequest request, CancellationToken ct = default)
        => _http.PostAsync<ShortLinkFetchResponse>("/cgi-bin/shorten/fetch", request, ct);
}

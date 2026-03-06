using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序内容安全服务实现</summary>
public class MiniProgramSecurityService : IMiniProgramSecurityService
{
    private readonly WechatHttpClient _http;

    public MiniProgramSecurityService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<MsgSecCheckResponse> MsgSecCheckAsync(MsgSecCheckRequest request, CancellationToken ct = default)
        => _http.PostAsync<MsgSecCheckResponse>("/wxa/msg_sec_check", request, ct);

    /// <inheritdoc/>
    public Task<MediaCheckAsyncResponse> MediaCheckAsync(MediaCheckAsyncRequest request, CancellationToken ct = default)
        => _http.PostAsync<MediaCheckAsyncResponse>("/wxa/media_check_async", request, ct);

    /// <inheritdoc/>
    public Task<GetUserRiskRankResponse> GetUserRiskRankAsync(GetUserRiskRankRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetUserRiskRankResponse>("/wxa/getuserriskrank", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序发货信息管理服务


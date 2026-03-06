using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序码服务实现</summary>
public class MiniProgramQrCodeService : IMiniProgramQrCodeService
{
    private readonly WechatHttpClient _http;

    public MiniProgramQrCodeService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<byte[]> GetUnlimitedAsync(GetUnlimitedQrCodeRequest request, CancellationToken ct = default)
        => _http.PostForBytesAsync("/wxa/getwxacodeunlimit", request, ct);

    /// <inheritdoc/>
    public Task<byte[]> GetQrCodeAsync(GetQrCodeRequest request, CancellationToken ct = default)
        => _http.PostForBytesAsync("/wxa/getwxacode", request, ct);

    /// <inheritdoc/>
    public Task<byte[]> CreateQrCodeAsync(CreateQrCodeRequest request, CancellationToken ct = default)
        => _http.PostForBytesAsync("/cgi-bin/wxaapp/createwxaqrcode", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序订阅消息服务


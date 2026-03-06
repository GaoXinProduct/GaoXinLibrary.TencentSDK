using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序硬件设备服务实现</summary>
public class MiniProgramDeviceService : IMiniProgramDeviceService
{
    private readonly WechatHttpClient _http;
    public MiniProgramDeviceService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<SendDeviceMessageResponse> SendMessageAsync(SendDeviceMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendDeviceMessageResponse>("/cgi-bin/message/device/subscribe/send", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序客服消息服务


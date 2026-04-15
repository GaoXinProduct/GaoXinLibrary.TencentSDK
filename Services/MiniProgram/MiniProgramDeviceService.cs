using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序硬件设备服务实现</summary>
public class MiniProgramDeviceService
{
    private readonly WechatHttpClient _http;
    public MiniProgramDeviceService(WechatHttpClient http) => _http = http;

    /// <summary>发送设备消息（POST /cgi-bin/message/device/subscribe/send）</summary>
    public Task<SendDeviceMessageResponse> SendMessageAsync(SendDeviceMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendDeviceMessageResponse>("/cgi-bin/message/device/subscribe/send", request, ct);
}

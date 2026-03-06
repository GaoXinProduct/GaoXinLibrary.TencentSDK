using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序订阅消息服务实现</summary>
public class MiniProgramSubscribeMessageService : IMiniProgramSubscribeMessageService
{
    private readonly WechatHttpClient _http;

    public MiniProgramSubscribeMessageService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<SendSubscribeMessageResponse> SendAsync(SendSubscribeMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendSubscribeMessageResponse>("/cgi-bin/message/subscribe/send", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序内容安全服务


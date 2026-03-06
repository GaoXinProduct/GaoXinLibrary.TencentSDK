using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序客服消息服务实现</summary>
public class MiniProgramCustomMessageService : IMiniProgramCustomMessageService
{
    private readonly WechatHttpClient _http;
    public MiniProgramCustomMessageService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<SendCustomMessageResponse> SendAsync(SendCustomMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendCustomMessageResponse>("/cgi-bin/message/custom/send", request, ct);
    /// <inheritdoc/>
    public Task<SetTypingResponse> SetTypingAsync(SetTypingRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetTypingResponse>("/cgi-bin/message/custom/typing", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序 OpenAPI 管理服务


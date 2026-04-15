using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序客服消息服务实现</summary>
public class MiniProgramCustomMessageService
{
    private readonly WechatHttpClient _http;
    public MiniProgramCustomMessageService(WechatHttpClient http) => _http = http;

    /// <summary>发送客服消息（POST /cgi-bin/message/custom/send）</summary>
    public Task<SendCustomMessageResponse> SendAsync(SendCustomMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendCustomMessageResponse>("/cgi-bin/message/custom/send", request, ct);
    /// <summary>下发客服当前输入状态（POST /cgi-bin/message/custom/typing）</summary>
    public Task<SetTypingResponse> SetTypingAsync(SetTypingRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetTypingResponse>("/cgi-bin/message/custom/typing", request, ct);
}

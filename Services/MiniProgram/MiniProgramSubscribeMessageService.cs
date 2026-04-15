using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序订阅消息服务实现</summary>
public class MiniProgramSubscribeMessageService
{
    private readonly WechatHttpClient _http;

    public MiniProgramSubscribeMessageService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 发送订阅消息（subscribeMessage.send）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SendSubscribeMessageResponse> SendAsync(SendSubscribeMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendSubscribeMessageResponse>("/cgi-bin/message/subscribe/send", request, ct);
}

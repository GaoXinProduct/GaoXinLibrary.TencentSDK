using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号模板消息服务实现</summary>
public class OfficialTemplateMessageService : IOfficialTemplateMessageService
{
    private readonly WechatHttpClient _http;

    public OfficialTemplateMessageService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<SendTemplateMessageResponse> SendAsync(SendTemplateMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendTemplateMessageResponse>("/cgi-bin/message/template/send", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号用户管理服务


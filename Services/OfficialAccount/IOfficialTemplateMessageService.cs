using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号模板消息服务接口
/// </summary>
public interface IOfficialTemplateMessageService
{
    /// <summary>
    /// 发送模板消息
    /// </summary>
    /// <param name="request">模板消息请求</param>
    /// <param name="ct">取消令牌</param>
    Task<SendTemplateMessageResponse> SendAsync(SendTemplateMessageRequest request, CancellationToken ct = default);
}


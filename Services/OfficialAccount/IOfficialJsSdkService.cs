using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号 JS-SDK 服务接口
/// <para>
/// 提供 JS-SDK 所需的 jsapi_ticket 获取和签名计算功能。
/// </para>
/// </summary>
public interface IOfficialJsSdkService
{
    /// <summary>
    /// 获取 jsapi_ticket
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task<GetJsApiTicketResponse> GetTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 计算 JS-SDK 签名（用于 wx.config）
    /// </summary>
    /// <param name="ticket">jsapi_ticket</param>
    /// <param name="url">当前网页 URL（不含 # 及后面部分）</param>
    JsSdkSignature CreateSignature(string ticket, string url);
}


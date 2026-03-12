using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 上传发票 PDF 响应
/// </summary>
public class InvoicePlatformSetPdfResponse : WechatBaseResponse
{
    /// <summary>发票 PDF 的媒体标识</summary>
    [JsonPropertyName("s_media_id")] public string? SMediaId { get; set; }
}

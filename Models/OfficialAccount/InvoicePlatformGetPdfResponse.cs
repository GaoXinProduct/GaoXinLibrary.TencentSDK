using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询已上传 PDF 响应
/// </summary>
public class InvoicePlatformGetPdfResponse : WechatBaseResponse
{
    /// <summary>PDF 下载地址</summary>
    [JsonPropertyName("pdf_url")] public string? PdfUrl { get; set; }

    /// <summary>PDF 地址过期时间（秒）</summary>
    [JsonPropertyName("pdf_url_expire_time")] public int? PdfUrlExpireTime { get; set; }
}

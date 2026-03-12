using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询已上传 PDF 请求
/// </summary>
public class InvoicePlatformGetPdfRequest
{
    /// <summary>固定填 get_url</summary>
    [JsonPropertyName("action")] public required string Action { get; set; } = "get_url";

    /// <summary>发票 s_media_id</summary>
    [JsonPropertyName("s_media_id")] public required string SMediaId { get; set; }
}

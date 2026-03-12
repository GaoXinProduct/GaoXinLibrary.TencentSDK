using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 解析抬头二维码请求
/// </summary>
public class InvoiceScanTitleRequest
{
    [JsonPropertyName("scan_text")] public required string ScanText { get; set; }
}

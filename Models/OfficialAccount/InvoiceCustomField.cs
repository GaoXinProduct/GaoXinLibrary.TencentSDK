using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票授权页自定义字段
/// </summary>
public class InvoiceCustomField
{
    /// <summary>字段名</summary>
    [JsonPropertyName("key")] public required string Key { get; set; }

    /// <summary>是否必填，0 否，1 是</summary>
    [JsonPropertyName("is_require")] public int? IsRequire { get; set; }

    /// <summary>提示文案</summary>
    [JsonPropertyName("notice")] public string? Notice { get; set; }
}

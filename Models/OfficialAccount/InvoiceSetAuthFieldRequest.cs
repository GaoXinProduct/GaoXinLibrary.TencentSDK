using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 设置授权页字段请求
/// </summary>
public class InvoiceSetAuthFieldRequest
{
    /// <summary>授权页字段</summary>
    [JsonPropertyName("auth_field")] public required InvoiceAuthField AuthField { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票卡券模板对象
/// </summary>
public class InvoicePlatformCardInfo
{
    [JsonPropertyName("base_info")] public required InvoicePlatformCardBaseInfo BaseInfo { get; set; }
}

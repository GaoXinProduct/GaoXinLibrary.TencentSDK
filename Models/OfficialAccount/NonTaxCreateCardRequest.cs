using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 创建财政电子票据模板请求
/// </summary>
public sealed class NonTaxCreateCardRequest
{
    [JsonPropertyName("base_info")] public required NonTaxCardBaseInfo BaseInfo { get; set; }
}

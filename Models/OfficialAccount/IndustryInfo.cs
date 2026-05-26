using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>行业信息</summary>
public sealed class IndustryInfo
{
    [JsonPropertyName("first_class")] public string? FirstClass { get; set; }
    [JsonPropertyName("second_class")] public string? SecondClass { get; set; }
}


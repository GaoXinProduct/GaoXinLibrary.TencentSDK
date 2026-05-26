using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>分布键值</summary>
public sealed class DistributionKeyValue
{
    [JsonPropertyName("key")] public int Key { get; set; }
    [JsonPropertyName("value")] public int Value { get; set; }
}


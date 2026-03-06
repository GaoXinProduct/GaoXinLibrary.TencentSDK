using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>分布键值</summary>
public class DistributionKeyValue
{
    [JsonPropertyName("key")] public int Key { get; set; }
    [JsonPropertyName("value")] public int Value { get; set; }
}


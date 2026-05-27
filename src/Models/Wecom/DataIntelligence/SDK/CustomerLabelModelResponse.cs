using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class CustomerLabelModelResponse : WecomBaseResponse
{
    [JsonPropertyName("labels")]
    public CustomerLabel[]? Labels { get; set; }
}

public class CustomerLabel
{
    [JsonPropertyName("label_name")]
    public string? LabelName { get; set; }

    [JsonPropertyName("label_type")]
    public string? LabelType { get; set; }
}
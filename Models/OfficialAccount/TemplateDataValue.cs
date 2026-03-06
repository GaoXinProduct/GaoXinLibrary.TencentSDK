using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>模板数据值</summary>
public class TemplateDataValue
{
    /// <summary>数据值</summary>
    [JsonPropertyName("value")] public required string Value { get; set; }

    /// <summary>字体颜色（可选）</summary>
    [JsonPropertyName("color")] public string? Color { get; set; }
}


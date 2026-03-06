using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>多语言文本</summary>
public class ApprovalText
{
    /// <summary>语言类型，zh_CN / en</summary>
    [JsonPropertyName("lang")] public string? Lang { get; set; }

    /// <summary>文字</summary>
    [JsonPropertyName("text")] public string? Text { get; set; }
}


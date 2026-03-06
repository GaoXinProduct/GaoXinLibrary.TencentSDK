using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>二级标题+文本列表项</summary>
public class TemplateCardHorizontalContent
{
    /// <summary>链接类型：0=普通文本, 1=跳转url, 2=下载附件, 3=@员工</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>二级标题（建议不超过5个字）</summary>
    [JsonPropertyName("keyname")] public string KeyName { get; set; } = string.Empty;

    /// <summary>二级文本（type=0/1/2 时使用）</summary>
    [JsonPropertyName("value")] public string? Value { get; set; }

    /// <summary>链接跳转的 URL（type=1 时使用）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>附件的 media_id（type=2 时使用）</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }

    /// <summary>@的成员的 userid（type=3 时使用）</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}


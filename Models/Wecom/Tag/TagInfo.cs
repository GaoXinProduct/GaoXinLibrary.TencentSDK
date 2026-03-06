using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

// ─── 标签信息 ──────────────────────────────────────────────────────────────

/// <summary>标签信息</summary>
public class TagInfo
{
    [JsonPropertyName("tagid")] public int TagId { get; set; }
    [JsonPropertyName("tagname")] public string? TagName { get; set; }
}


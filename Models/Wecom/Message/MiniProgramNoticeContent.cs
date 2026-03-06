using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public class MiniProgramNoticeContent
{
    [JsonPropertyName("appid")] public string AppId { get; set; } = string.Empty;
    [JsonPropertyName("page")] public string? Page { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("emphasis_first_item")] public bool? EmphasisFirstItem { get; set; }
    [JsonPropertyName("content_item")] public MiniProgramContentItem[]? ContentItem { get; set; }
}


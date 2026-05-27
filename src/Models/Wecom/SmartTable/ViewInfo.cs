using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>视图信息</summary>
public class ViewInfo
{
    /// <summary>视图 ID</summary>
    [JsonPropertyName("view_id")] public string? ViewId { get; set; }

    /// <summary>视图标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>视图类型</summary>
    [JsonPropertyName("view_type")] public string? ViewType { get; set; }

    /// <summary>是否为默认视图</summary>
    [JsonPropertyName("is_default")] public bool? IsDefault { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>智能表格视图信息</summary>
public class SheetView
{
    /// <summary>视图ID</summary>
    [JsonPropertyName("view_id")] public string? ViewId { get; set; }

    /// <summary>视图标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>视图类型：VIEW_TYPE_GRID / VIEW_TYPE_KANBAN / VIEW_TYPE_GALLERY 等</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>是否为默认视图</summary>
    [JsonPropertyName("is_default")] public bool? IsDefault { get; set; }
}

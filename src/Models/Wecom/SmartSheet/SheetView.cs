
namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>智能表格视图信息</summary>
public sealed class SheetView
{
    /// <summary>视图ID</summary>
    [JsonPropertyName("view_id")] public string? ViewId { get; set; }

    /// <summary>视图标题</summary>
    [JsonPropertyName("view_title")] public string? Title { get; set; }

    /// <summary>视图类型：VIEW_TYPE_GRID / VIEW_TYPE_KANBAN / VIEW_TYPE_GALLERY 等</summary>
    [JsonPropertyName("view_type")] public string? Type { get; set; }

    /// <summary>视图设置，包括筛选、分组、排序和字段可见性等属性。</summary>
    [JsonPropertyName("property")] public JsonElement? Property { get; set; }

    /// <summary>是否为默认视图</summary>
    [JsonPropertyName("is_default")] public bool? IsDefault { get; set; }
}

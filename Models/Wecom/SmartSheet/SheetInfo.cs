using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>智能表格子表信息</summary>
public class SheetInfo
{
    /// <summary>子表ID</summary>
    [JsonPropertyName("sheet_id")] public string? SheetId { get; set; }

    /// <summary>子表标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>是否为默认子表</summary>
    [JsonPropertyName("is_default")] public bool? IsDefault { get; set; }
}

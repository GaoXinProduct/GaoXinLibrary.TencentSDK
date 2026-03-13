using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>修改子表属性项</summary>
public class UpdateSheetProperty
{
    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;

    /// <summary>子表标题</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
}

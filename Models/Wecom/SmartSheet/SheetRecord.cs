using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>智能表格记录</summary>
public class SheetRecord
{
    /// <summary>记录ID</summary>
    [JsonPropertyName("record_id")] public string? RecordId { get; set; }

    /// <summary>记录值，key为字段ID，value为对应值</summary>
    [JsonPropertyName("values")] public Dictionary<string, object>? Values { get; set; }
}

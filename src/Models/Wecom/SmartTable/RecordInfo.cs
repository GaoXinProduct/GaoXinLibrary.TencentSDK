using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>记录信息</summary>
public class RecordInfo
{
    /// <summary>记录 ID</summary>
    [JsonPropertyName("record_id")] public string? RecordId { get; set; }

    /// <summary>字段 ID 到值的映射</summary>
    [JsonPropertyName("values")] public Dictionary<string, object>? Values { get; set; }
}

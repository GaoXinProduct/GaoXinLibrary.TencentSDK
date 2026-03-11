using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>员工字段值</summary>
public class StaffFieldValue
{
    /// <summary>字段id</summary>
    [JsonPropertyName("fieldid")] public int FieldId { get; set; }

    /// <summary>字段值</summary>
    [JsonPropertyName("value_string")] public string? ValueString { get; set; }
}

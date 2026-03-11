using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>员工花名册信息</summary>
public class StaffInfo
{
    /// <summary>成员userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>字段值列表</summary>
    [JsonPropertyName("field_value_list")] public StaffFieldValue[]? FieldValueList { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>花名册字段分组</summary>
public class HrFieldGroup
{
    /// <summary>分组id</summary>
    [JsonPropertyName("group_id")] public int GroupId { get; set; }

    /// <summary>分组名称</summary>
    [JsonPropertyName("group_name")] public string? GroupName { get; set; }

    /// <summary>字段列表</summary>
    [JsonPropertyName("field_list")] public HrField[]? FieldList { get; set; }
}

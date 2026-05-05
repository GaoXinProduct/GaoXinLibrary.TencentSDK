using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>编组信息</summary>
public class GroupInfo
{
    /// <summary>编组 ID</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; set; }

    /// <summary>编组名称</summary>
    [JsonPropertyName("group_name")] public string? GroupName { get; set; }

    /// <summary>分组字段 ID</summary>
    [JsonPropertyName("field_id")] public string? FieldId { get; set; }

    /// <summary>编组类型</summary>
    [JsonPropertyName("group_type")] public string? GroupType { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>更新员工信息请求</summary>
public class UpdateStaffInfoRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>字段值列表</summary>
    [JsonPropertyName("field_value_list")]
    public StaffFieldValue[] FieldValueList { get; set; } = [];
}

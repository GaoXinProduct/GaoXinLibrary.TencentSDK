using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>获取员工花名册信息响应</summary>
public class GetStaffInfoResponse : WecomBaseResponse
{
    /// <summary>员工信息列表</summary>
    [JsonPropertyName("employee")] public StaffInfo[]? Employee { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

public class GetDepartmentResponse : WecomBaseResponse
{
    [JsonPropertyName("department")] public DepartmentInfo? Department { get; set; }
}


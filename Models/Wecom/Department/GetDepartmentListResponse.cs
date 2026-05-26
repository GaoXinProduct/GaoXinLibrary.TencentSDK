using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

public sealed class GetDepartmentListResponse : WecomBaseResponse
{
    [JsonPropertyName("department")] public DepartmentInfo[]? Department { get; set; }
}


using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

#region 响应模型

public sealed class CreateDepartmentResponse : WecomBaseResponse
{
    [JsonPropertyName("id")] public int Id { get; set; }
}

#endregion

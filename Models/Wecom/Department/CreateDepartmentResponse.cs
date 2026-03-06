using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

// ─── 响应模型 ──────────────────────────────────────────────────────────────

public class CreateDepartmentResponse : WecomBaseResponse
{
    [JsonPropertyName("id")] public int Id { get; set; }
}


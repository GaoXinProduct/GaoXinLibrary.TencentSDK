using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>获取员工字段配置响应</summary>
public class GetFieldConfigResponse : WecomBaseResponse
{
    /// <summary>字段配置列表</summary>
    [JsonPropertyName("group")] public HrFieldGroup[]? Group { get; set; }
}

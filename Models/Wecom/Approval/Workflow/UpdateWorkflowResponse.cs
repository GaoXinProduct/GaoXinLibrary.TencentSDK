using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>更新审批模板响应（新版）</summary>
public class UpdateWorkflowResponse : WecomBaseResponse
{
    /// <summary>更新时间（Unix 时间戳）</summary>
    [JsonPropertyName("update_time")]
    public long UpdateTime { get; set; }
}
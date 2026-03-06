using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>提交审批申请响应</summary>
public class ApplyEventResponse : WecomBaseResponse
{
    /// <summary>审批单号</summary>
    [JsonPropertyName("sp_no")] public string? SpNo { get; set; }
}


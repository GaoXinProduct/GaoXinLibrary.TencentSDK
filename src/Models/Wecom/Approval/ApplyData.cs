using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批申请数据</summary>
public sealed class ApplyData
{
    /// <summary>审批申请详情</summary>
    [JsonPropertyName("contents")] public ApplyContent[]? Contents { get; set; }
}


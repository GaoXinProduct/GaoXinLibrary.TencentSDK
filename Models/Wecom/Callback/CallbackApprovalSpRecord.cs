namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>审批回调 - 审批流程节点</summary>
public class CallbackApprovalSpRecord
{
    /// <summary>
    /// 审批节点状态
    /// <para>1-审批中 2-已同意 3-已驳回 4-已转审</para>
    /// </summary>
    public int SpStatus { get; set; }

    /// <summary>节点审批方式：1-或签 2-会签</summary>
    public int ApproverAttr { get; set; }

    /// <summary>审批节点详情列表</summary>
    public CallbackApprovalSpDetail[]? Details { get; set; }
}

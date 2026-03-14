namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>审批回调 - 审批节点详情</summary>
public class CallbackApprovalSpDetail
{
    /// <summary>审批人 userid</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>审批意见</summary>
    public string Speech { get; set; } = string.Empty;

    /// <summary>
    /// 审批状态
    /// <para>1-审批中 2-已同意 3-已驳回 4-已转审</para>
    /// </summary>
    public int SpStatus { get; set; }

    /// <summary>审批操作时间（Unix 时间戳）</summary>
    public long SpTime { get; set; }
}

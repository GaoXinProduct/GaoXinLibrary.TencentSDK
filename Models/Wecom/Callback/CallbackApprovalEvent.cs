namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 审批申请状态变化回调事件
/// <para>
/// 当审批申请的状态发生变化时（如提交、审批通过、驳回、撤销等），企业微信会推送此事件。<br/>
/// 对应事件类型：<c>open_approval_change</c><br/>
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/91815"/>
/// </para>
/// </summary>
public class CallbackApprovalEvent : CallbackEventBase
{
    /// <summary>审批单号</summary>
    public string SpNo { get; set; } = string.Empty;

    /// <summary>审批模板名称</summary>
    public string SpName { get; set; } = string.Empty;

    /// <summary>
    /// 审批单状态
    /// <para>1-审批中 2-已通过 3-已驳回 4-已撤销 6-通过后撤销 7-已删除 10-已支付</para>
    /// </summary>
    public int SpStatus { get; set; }

    /// <summary>审批模板 id</summary>
    public string TemplateId { get; set; } = string.Empty;

    /// <summary>申请时间（Unix 时间戳）</summary>
    public long ApplyTime { get; set; }

    /// <summary>申请人 userid</summary>
    public string ApplyerUserId { get; set; } = string.Empty;

    /// <summary>申请人所在部门 id</summary>
    public string ApplyerPartyId { get; set; } = string.Empty;

    /// <summary>
    /// 审批状态变化类型
    /// <para>1-提交审批申请 2-审批流程结束（通过/驳回） 4-已撤销 10-已支付</para>
    /// </summary>
    public int StatuChangeEvent { get; set; }

    /// <summary>审批流程节点信息列表</summary>
    public CallbackApprovalSpRecord[]? SpRecords { get; set; }

    /// <summary>抄送人 userid 列表</summary>
    public string[]? NotifyerUserIds { get; set; }

    /// <summary>审批备注列表</summary>
    public CallbackApprovalComment[]? Comments { get; set; }
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>审批回调 - 审批备注</summary>
public class CallbackApprovalComment
{
    /// <summary>备注人 userid</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>备注提交时间（Unix 时间戳）</summary>
    public long CommentTime { get; set; }

    /// <summary>备注内容</summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>备注 id</summary>
    public string CommentId { get; set; } = string.Empty;
}

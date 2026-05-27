namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 日程回执事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/98111"/></para>
/// </summary>
public class ScheduleReceiptEvent : CallbackEventBase
{
    /// <summary>日程 ID</summary>
    public string ScheduleId { get; set; } = string.Empty;

    /// <summary>日历 ID</summary>
    public string CalId { get; set; } = string.Empty;

    /// <summary>回执状态（1-待定 2-接受 3-拒绝）</summary>
    public int ReceiptStatus { get; set; }

    /// <summary>用户 UserID</summary>
    public string UserId { get; set; } = string.Empty;
}
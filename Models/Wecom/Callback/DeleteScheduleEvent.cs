namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 删除日程事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97732"/></para>
/// </summary>
public class DeleteScheduleEvent : CallbackEventBase
{
    /// <summary>日程 ID</summary>
    public string ScheduleId { get; set; } = string.Empty;

    /// <summary>日历 ID</summary>
    public string CalId { get; set; } = string.Empty;
}
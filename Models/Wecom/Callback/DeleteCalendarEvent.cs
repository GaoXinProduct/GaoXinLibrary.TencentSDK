namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 删除日历事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97728"/></para>
/// </summary>
public class DeleteCalendarEvent : CallbackEventBase
{
    /// <summary>日历 ID</summary>
    public string CalId { get; set; } = string.Empty;
}
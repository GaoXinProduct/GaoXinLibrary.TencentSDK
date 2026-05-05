namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 修改日历事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97730"/></para>
/// </summary>
public class ModifyCalendarEvent : CallbackEventBase
{
    /// <summary>日历 ID</summary>
    public string CalId { get; set; } = string.Empty;
}
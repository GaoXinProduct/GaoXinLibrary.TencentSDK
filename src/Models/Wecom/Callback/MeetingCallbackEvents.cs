namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 会议事件基类
/// </summary>
public abstract class MeetingCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 会议变更事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/99103"/></para>
/// </summary>
public class MeetingChangeEvent : MeetingCallbackEventBase
{
    /// <summary>会议 ID</summary>
    public string MeetingId { get; set; } = string.Empty;

    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>会议主题</summary>
    public string? Subject { get; set; }

    /// <summary>会议开始时间</summary>
    public long StartTime { get; set; }

    /// <summary>会议结束时间</summary>
    public long EndTime { get; set; }
}
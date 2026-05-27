namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 直播状态变更事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/94145"/></para>
/// </summary>
public class LivingStateChangeEvent : CallbackEventBase
{
    /// <summary>直播 ID</summary>
    public string LivingUuid { get; set; } = string.Empty;

    /// <summary>事件类型（living_started/living_ended/living_canceled）</summary>
    public string EventName { get; set; } = string.Empty;

    /// <summary>直播开始时间</summary>
    public long StartTime { get; set; }

    /// <summary>直播结束时间</summary>
    public long EndTime { get; set; }

    /// <summary>直播主题</summary>
    public string? Subject { get; set; }

    /// <summary>主播 userid</summary>
    public string? AnchorUserId { get; set; }
}
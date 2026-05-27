using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>创建日历响应</summary>
public sealed class CreateCalendarResponse : WecomBaseResponse
{
    /// <summary>日历ID</summary>
    [JsonPropertyName("cal_id")] public string? CalId { get; set; }
}

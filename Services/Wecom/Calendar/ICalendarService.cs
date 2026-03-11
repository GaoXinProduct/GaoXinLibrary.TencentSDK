using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>日程服务接口</summary>
public interface ICalendarService
{
    /// <summary>创建日历</summary>
    Task<string?> CreateCalendarAsync(CalendarInfo calendar, CancellationToken ct = default);

    /// <summary>更新日历</summary>
    Task UpdateCalendarAsync(CalendarInfo calendar, CancellationToken ct = default);

    /// <summary>获取日历详情</summary>
    Task<CalendarInfo[]> GetCalendarAsync(string[] calIds, CancellationToken ct = default);

    /// <summary>删除日历</summary>
    Task DeleteCalendarAsync(string calId, CancellationToken ct = default);

    /// <summary>创建日程</summary>
    Task<string?> CreateScheduleAsync(ScheduleInfo schedule, CancellationToken ct = default);

    /// <summary>更新日程</summary>
    Task UpdateScheduleAsync(ScheduleInfo schedule, CancellationToken ct = default);

    /// <summary>获取日程详情</summary>
    Task<ScheduleInfo[]> GetScheduleAsync(string[] scheduleIds, CancellationToken ct = default);

    /// <summary>取消日程</summary>
    Task CancelScheduleAsync(string scheduleId, CancellationToken ct = default);

    /// <summary>获取日历下的日程列表</summary>
    Task<ScheduleInfo[]> GetScheduleByCalendarAsync(string calId, int? offset = null, int? limit = null, CancellationToken ct = default);
}

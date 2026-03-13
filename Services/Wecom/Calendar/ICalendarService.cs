using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>日程服务接口</summary>
public interface ICalendarService
{
    /// <summary>创建日历</summary>
    Task<string?> CreateCalendarAsync(CreateCalendarRequest request, CancellationToken ct = default);

    /// <summary>更新日历</summary>
    Task UpdateCalendarAsync(UpdateCalendarRequest request, CancellationToken ct = default);

    /// <summary>获取日历详情</summary>
    Task<CalendarInfo[]> GetCalendarAsync(GetCalendarRequest request, CancellationToken ct = default);

    /// <summary>删除日历</summary>
    Task DeleteCalendarAsync(DeleteCalendarRequest request, CancellationToken ct = default);

    /// <summary>创建日程</summary>
    Task<string?> CreateScheduleAsync(CreateScheduleRequest request, CancellationToken ct = default);

    /// <summary>更新日程</summary>
    Task UpdateScheduleAsync(UpdateScheduleRequest request, CancellationToken ct = default);

    /// <summary>获取日程详情</summary>
    Task<ScheduleInfo[]> GetScheduleAsync(GetScheduleRequest request, CancellationToken ct = default);

    /// <summary>取消日程</summary>
    Task CancelScheduleAsync(CancelScheduleRequest request, CancellationToken ct = default);

    /// <summary>获取日历下的日程列表</summary>
    Task<ScheduleInfo[]> GetScheduleByCalendarAsync(GetScheduleByCalendarRequest request, CancellationToken ct = default);
}

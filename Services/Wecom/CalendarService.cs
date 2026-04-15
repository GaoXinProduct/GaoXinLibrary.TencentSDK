using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>日程服务实现</summary>
public class CalendarService
{
    private readonly WecomHttpClient _http;

    public CalendarService(WecomHttpClient http) => _http = http;

    /// <summary>创建日历</summary>
    public async Task<string?> CreateCalendarAsync(CreateCalendarRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateCalendarResponse>("/cgi-bin/oa/calendar/add", request, ct);
        return resp.CalId;
    }

    /// <summary>更新日历</summary>
    public async Task UpdateCalendarAsync(UpdateCalendarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/calendar/update", request, ct);

    /// <summary>获取日历详情</summary>
    public async Task<CalendarInfo[]> GetCalendarAsync(GetCalendarRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCalendarResponse>("/cgi-bin/oa/calendar/get", request, ct);
        return resp.CalendarList ?? [];
    }

    /// <summary>删除日历</summary>
    public async Task DeleteCalendarAsync(DeleteCalendarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/calendar/del", request, ct);

    /// <summary>创建日程</summary>
    public async Task<string?> CreateScheduleAsync(CreateScheduleRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateScheduleResponse>("/cgi-bin/oa/schedule/add", request, ct);
        return resp.ScheduleId;
    }

    /// <summary>更新日程</summary>
    public async Task UpdateScheduleAsync(UpdateScheduleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/update", request, ct);

    /// <summary>获取日程详情</summary>
    public async Task<ScheduleInfo[]> GetScheduleAsync(GetScheduleRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleResponse>("/cgi-bin/oa/schedule/get", request, ct);
        return resp.ScheduleList ?? [];
    }

    /// <summary>取消日程</summary>
    public async Task CancelScheduleAsync(CancelScheduleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/del", request, ct);

    /// <summary>获取日历下的日程列表</summary>
    public async Task<ScheduleInfo[]> GetScheduleByCalendarAsync(GetScheduleByCalendarRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleResponse>("/cgi-bin/oa/schedule/get_by_calendar", request, ct);
        return resp.ScheduleList ?? [];
    }
}

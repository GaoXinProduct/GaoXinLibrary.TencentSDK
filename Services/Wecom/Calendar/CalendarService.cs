using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>日程服务实现</summary>
public class CalendarService : ICalendarService
{
    private readonly WecomHttpClient _http;

    public CalendarService(WecomHttpClient http) => _http = http;

    public async Task<string?> CreateCalendarAsync(CalendarInfo calendar, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateCalendarResponse>("/cgi-bin/oa/calendar/add",
            new { calendar }, ct);
        return resp.CalId;
    }

    public async Task UpdateCalendarAsync(CalendarInfo calendar, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/calendar/update",
            new { calendar }, ct);

    public async Task<CalendarInfo[]> GetCalendarAsync(string[] calIds, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCalendarResponse>("/cgi-bin/oa/calendar/get",
            new { cal_id_list = calIds }, ct);
        return resp.CalendarList ?? [];
    }

    public async Task DeleteCalendarAsync(string calId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/calendar/del",
            new { cal_id = calId }, ct);

    public async Task<string?> CreateScheduleAsync(ScheduleInfo schedule, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateScheduleResponse>("/cgi-bin/oa/schedule/add",
            new { schedule }, ct);
        return resp.ScheduleId;
    }

    public async Task UpdateScheduleAsync(ScheduleInfo schedule, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/update",
            new { schedule }, ct);

    public async Task<ScheduleInfo[]> GetScheduleAsync(string[] scheduleIds, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleResponse>("/cgi-bin/oa/schedule/get",
            new { schedule_id_list = scheduleIds }, ct);
        return resp.ScheduleList ?? [];
    }

    public async Task CancelScheduleAsync(string scheduleId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/del",
            new { schedule_id = scheduleId }, ct);

    public async Task<ScheduleInfo[]> GetScheduleByCalendarAsync(string calId, int? offset = null, int? limit = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleResponse>("/cgi-bin/oa/schedule/get_by_calendar",
            new { cal_id = calId, offset, limit }, ct);
        return resp.ScheduleList ?? [];
    }
}

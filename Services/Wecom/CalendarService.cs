using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>日程服务实现</summary>
public sealed class CalendarService
{
    private readonly WecomHttpClient _http;

    public CalendarService(WecomHttpClient http) => _http = http;

    /// <summary>创建日历</summary>
    public async Task<string?> CreateCalendarAsync(CreateCalendarRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateCalendarResponse>("/cgi-bin/oa/calendar/add", request, ct).ConfigureAwait(false);
        return resp.CalId;
    }

    /// <summary>更新日历</summary>
    public async Task UpdateCalendarAsync(UpdateCalendarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/calendar/update", request, ct).ConfigureAwait(false);

    /// <summary>获取日历详情</summary>
    public async Task<CalendarInfo[]> GetCalendarAsync(GetCalendarRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCalendarResponse>("/cgi-bin/oa/calendar/get", request, ct).ConfigureAwait(false);
        return resp.CalendarList ?? [];
    }

    /// <summary>删除日历</summary>
    public async Task DeleteCalendarAsync(DeleteCalendarRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/calendar/del", request, ct).ConfigureAwait(false);

    /// <summary>创建日程</summary>
    public async Task<string?> CreateScheduleAsync(CreateScheduleRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateScheduleResponse>("/cgi-bin/oa/schedule/add", request, ct).ConfigureAwait(false);
        return resp.ScheduleId;
    }

    /// <summary>更新日程</summary>
    public async Task UpdateScheduleAsync(UpdateScheduleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/update", request, ct).ConfigureAwait(false);

    /// <summary>获取日程详情</summary>
    public async Task<ScheduleInfo[]> GetScheduleAsync(GetScheduleRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleResponse>("/cgi-bin/oa/schedule/get", request, ct).ConfigureAwait(false);
        return resp.ScheduleList ?? [];
    }

    /// <summary>取消日程</summary>
    public async Task CancelScheduleAsync(CancelScheduleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/del", request, ct).ConfigureAwait(false);

    /// <summary>获取日历下的日程列表</summary>
    public async Task<ScheduleInfo[]> GetScheduleByCalendarAsync(GetScheduleByCalendarRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleResponse>("/cgi-bin/oa/schedule/get_by_calendar", request, ct).ConfigureAwait(false);
        return resp.ScheduleList ?? [];
    }

    /// <summary>更新重复日程</summary>
    public async Task<string?> UpdateRecurringScheduleAsync(UpdateScheduleRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<UpdateScheduleResponse>("/cgi-bin/oa/schedule/update", request, ct);
        return resp.ScheduleId;
    }

    /// <summary>新增日程参与者</summary>
    public async Task<string?> AddScheduleAttendeesAsync(AddScheduleAttendeesRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddScheduleAttendeesResponse>("/cgi-bin/oa/schedule/add_attendees", request, ct);
        return resp.ScheduleId;
    }

    /// <summary>删除日程参与者</summary>
    public async Task DeleteScheduleAttendeesAsync(DeleteScheduleAttendeesRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/del_attendees", request, ct);

    /// <summary>获取日历下的日程列表</summary>
    public async Task<ScheduleInfo[]> GetScheduleListAsync(GetScheduleListRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleListResponse>("/cgi-bin/oa/schedule/get_by_calendar", request, ct);
        return resp.ScheduleList ?? [];
    }

    /// <summary>获取日程详情</summary>
    public async Task<ScheduleInfo[]> GetScheduleDetailAsync(GetScheduleDetailRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetScheduleDetailResponse>("/cgi-bin/oa/schedule/get", request, ct);
        return resp.ScheduleList ?? [];
    }

    /// <summary>取消重复日程</summary>
    public async Task CancelRecurringScheduleAsync(CancelScheduleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/schedule/del", request, ct);
}
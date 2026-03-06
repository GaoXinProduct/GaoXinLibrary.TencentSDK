using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>打卡服务实现</summary>
public class CheckinService : ICheckinService
{
    private readonly WecomHttpClient _http;

    public CheckinService(WecomHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public async Task<CheckinGroup[]> GetCorpCheckinOptionAsync(CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCorpCheckinOptionResponse>(
            "/cgi-bin/checkin/getcorpcheckinoption",
            new { }, ct);
        return resp.Group ?? [];
    }

    /// <inheritdoc/>
    public async Task<CheckinOptionInfo[]> GetCheckinOptionAsync(long dateTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinOptionResponse>(
            "/cgi-bin/checkin/getcheckinoption",
            new GetCheckinOptionRequest { DateTime = dateTime, UserIdList = userIdList }, ct);
        return resp.Info ?? [];
    }

    /// <inheritdoc/>
    public async Task<CheckinDataItem[]> GetCheckinDataAsync(int openCheckinDataType, long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinDataResponse>(
            "/cgi-bin/checkin/getcheckindata",
            new GetCheckinDataRequest
            {
                OpenCheckinDataType = openCheckinDataType,
                StartTime = startTime,
                EndTime = endTime,
                UserIdList = userIdList
            }, ct);
        return resp.CheckinData ?? [];
    }

    /// <inheritdoc/>
    public async Task<CheckinDayDataItem[]> GetCheckinDayDataAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinDayDataResponse>(
            "/cgi-bin/checkin/getcheckin_daydata",
            new GetCheckinDayDataRequest { StartTime = startTime, EndTime = endTime, UserIdList = userIdList }, ct);
        return resp.Datas ?? [];
    }

    /// <inheritdoc/>
    public async Task<CheckinMonthDataItem[]> GetCheckinMonthDataAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinMonthDataResponse>(
            "/cgi-bin/checkin/getcheckin_monthdata",
            new GetCheckinMonthDataRequest { StartTime = startTime, EndTime = endTime, UserIdList = userIdList }, ct);
        return resp.Datas ?? [];
    }

    /// <inheritdoc/>
    public async Task<CheckinScheduleItem[]> GetCheckinScheduleListAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinScheduleListResponse>(
            "/cgi-bin/checkin/getcheckinschedulist",
            new GetCheckinScheduleListRequest { StartTime = startTime, EndTime = endTime, UserIdList = userIdList }, ct);
        return resp.ScheduleList ?? [];
    }

    /// <inheritdoc/>
    public async Task SetCheckinScheduleListAsync(SetCheckinScheduleListRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/setcheckinschedulist", request, ct);
    }

    /// <inheritdoc/>
    public async Task AddCheckinUserFaceAsync(string userId, string userFace, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/addcheckinuserface",
            new AddCheckinUserFaceRequest { UserId = userId, UserFace = userFace }, ct);
    }

    /// <inheritdoc/>
    public async Task PunchCorrectionAsync(PunchCorrectionRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/punch_correction", request, ct);
    }

    /// <inheritdoc/>
    public async Task AddCheckinDataAsync(AddCheckinDataRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/addcheckindata", request, ct);
    }

    /// <inheritdoc/>
    public async Task<DeviceCheckinDataItem[]> GetCheckinDeviceDataAsync(GetCheckinDeviceDataRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinDeviceDataResponse>(
            "/cgi-bin/checkin/getcheckin_device_data", request, ct);
        return resp.CheckinData ?? [];
    }

    /// <inheritdoc/>
    public async Task<int> AddCheckinOptionAsync(AddCheckinOptionRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddCheckinOptionResponse>(
            "/cgi-bin/checkin/addcheckinoption", request, ct);
        return resp.Id;
    }

    /// <inheritdoc/>
    public async Task UpdateCheckinOptionAsync(UpdateCheckinOptionRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/updatecheckinoption", request, ct);
    }

    /// <inheritdoc/>
    public async Task ClearCheckinOptionAsync(int groupId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/clearcheckinoption",
            new ClearCheckinOptionRequest { GroupId = groupId }, ct);
    }
}

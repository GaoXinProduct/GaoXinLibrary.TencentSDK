using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>打卡服务实现</summary>
public class CheckinService
{
    private readonly WecomHttpClient _http;

    public CheckinService(WecomHttpClient http)
    {
        _http = http;
    }

    /// <summary>获取企业所有打卡规则</summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>打卡规则列表</returns>
    public async Task<CheckinGroup[]> GetCorpCheckinOptionAsync(CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCorpCheckinOptionResponse>(
            "/cgi-bin/checkin/getcorpcheckinoption",
            EmptyRequest.Instance, ct);
        return resp.Group ?? [];
    }

    /// <summary>获取员工打卡规则</summary>
    /// <param name="dateTime">需要获取规则的日期当天 0 点的 Unix 时间戳</param>
    /// <param name="userIdList">需要获取打卡规则的用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>员工打卡规则信息列表</returns>
    public async Task<CheckinOptionInfo[]> GetCheckinOptionAsync(long dateTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinOptionResponse>(
            "/cgi-bin/checkin/getcheckinoption",
            new GetCheckinOptionRequest { DateTime = dateTime, UserIdList = userIdList }, ct);
        return resp.Info ?? [];
    }

    /// <summary>获取打卡记录数据</summary>
    /// <param name="openCheckinDataType">打卡类型：1-上下班 2-外出 3-全部</param>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>打卡记录列表</returns>
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

    /// <summary>获取打卡日报数据</summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>日报数据列表</returns>
    public async Task<CheckinDayDataItem[]> GetCheckinDayDataAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinDayDataResponse>(
            "/cgi-bin/checkin/getcheckin_daydata",
            new GetCheckinDayDataRequest { StartTime = startTime, EndTime = endTime, UserIdList = userIdList }, ct);
        return resp.Datas ?? [];
    }

    /// <summary>获取打卡月报数据</summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>月报数据列表</returns>
    public async Task<CheckinMonthDataItem[]> GetCheckinMonthDataAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinMonthDataResponse>(
            "/cgi-bin/checkin/getcheckin_monthdata",
            new GetCheckinMonthDataRequest { StartTime = startTime, EndTime = endTime, UserIdList = userIdList }, ct);
        return resp.Datas ?? [];
    }

    /// <summary>获取打卡人员排班信息</summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>排班信息列表</returns>
    public async Task<CheckinScheduleItem[]> GetCheckinScheduleListAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinScheduleListResponse>(
            "/cgi-bin/checkin/getcheckinschedulist",
            new GetCheckinScheduleListRequest { StartTime = startTime, EndTime = endTime, UserIdList = userIdList }, ct);
        return resp.ScheduleList ?? [];
    }

    /// <summary>为打卡人员排班</summary>
    /// <param name="request">排班请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task SetCheckinScheduleListAsync(SetCheckinScheduleListRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/setcheckinschedulist", request, ct);
    }

    /// <summary>录入打卡人员人脸信息</summary>
    /// <param name="userId">用户 userid</param>
    /// <param name="userFace">人脸图片 base64</param>
    /// <param name="ct">取消令牌</param>
    public async Task AddCheckinUserFaceAsync(string userId, string userFace, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/addcheckinuserface",
            new AddCheckinUserFaceRequest { UserId = userId, UserFace = userFace }, ct);
    }

    /// <summary>为打卡人员补卡</summary>
    /// <param name="request">补卡请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task PunchCorrectionAsync(PunchCorrectionRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/punch_correction", request, ct);
    }

    /// <summary>添加打卡记录</summary>
    /// <param name="request">添加打卡记录请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task AddCheckinDataAsync(AddCheckinDataRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/addcheckindata", request, ct);
    }

    /// <summary>获取设备打卡数据</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>设备打卡记录列表</returns>
    public async Task<DeviceCheckinDataItem[]> GetCheckinDeviceDataAsync(GetCheckinDeviceDataRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCheckinDeviceDataResponse>(
            "/cgi-bin/checkin/getcheckin_device_data", request, ct);
        return resp.CheckinData ?? [];
    }

    /// <summary>添加打卡规则</summary>
    /// <param name="request">添加打卡规则请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>新增规则 id</returns>
    public async Task<int> AddCheckinOptionAsync(AddCheckinOptionRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddCheckinOptionResponse>(
            "/cgi-bin/checkin/addcheckinoption", request, ct);
        return resp.Id;
    }

    /// <summary>修改打卡规则</summary>
    /// <param name="request">修改打卡规则请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateCheckinOptionAsync(UpdateCheckinOptionRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/updatecheckinoption", request, ct);
    }

    /// <summary>清空打卡规则（删除指定规则下所有人员）</summary>
    /// <param name="groupId">打卡规则 id</param>
    /// <param name="ct">取消令牌</param>
    public async Task ClearCheckinOptionAsync(int groupId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/checkin/clearcheckinoption",
            new ClearCheckinOptionRequest { GroupId = groupId }, ct);
    }
}

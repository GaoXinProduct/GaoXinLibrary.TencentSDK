using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 打卡服务接口
/// <para>
/// 提供打卡规则查询、打卡记录获取、日报月报统计、排班管理及人脸录入等功能。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/93384"/>
/// </para>
/// </summary>
public interface ICheckinService
{
    /// <summary>获取企业所有打卡规则</summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>打卡规则列表</returns>
    Task<CheckinGroup[]> GetCorpCheckinOptionAsync(CancellationToken ct = default);

    /// <summary>获取员工打卡规则</summary>
    /// <param name="dateTime">需要获取规则的日期当天 0 点的 Unix 时间戳</param>
    /// <param name="userIdList">需要获取打卡规则的用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>员工打卡规则信息列表</returns>
    Task<CheckinOptionInfo[]> GetCheckinOptionAsync(long dateTime, string[] userIdList, CancellationToken ct = default);

    /// <summary>获取打卡记录数据</summary>
    /// <param name="openCheckinDataType">打卡类型：1-上下班 2-外出 3-全部</param>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>打卡记录列表</returns>
    Task<CheckinDataItem[]> GetCheckinDataAsync(int openCheckinDataType, long startTime, long endTime, string[] userIdList, CancellationToken ct = default);

    /// <summary>获取打卡日报数据</summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>日报数据列表</returns>
    Task<CheckinDayDataItem[]> GetCheckinDayDataAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default);

    /// <summary>获取打卡月报数据</summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>月报数据列表</returns>
    Task<CheckinMonthDataItem[]> GetCheckinMonthDataAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default);

    /// <summary>获取打卡人员排班信息</summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="userIdList">用户列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>排班信息列表</returns>
    Task<CheckinScheduleItem[]> GetCheckinScheduleListAsync(long startTime, long endTime, string[] userIdList, CancellationToken ct = default);

    /// <summary>为打卡人员排班</summary>
    /// <param name="request">排班请求</param>
    /// <param name="ct">取消令牌</param>
    Task SetCheckinScheduleListAsync(SetCheckinScheduleListRequest request, CancellationToken ct = default);

    /// <summary>录入打卡人员人脸信息</summary>
    /// <param name="userId">用户 userid</param>
    /// <param name="userFace">人脸图片 base64</param>
    /// <param name="ct">取消令牌</param>
    Task AddCheckinUserFaceAsync(string userId, string userFace, CancellationToken ct = default);

    /// <summary>为打卡人员补卡</summary>
    /// <param name="request">补卡请求</param>
    /// <param name="ct">取消令牌</param>
    Task PunchCorrectionAsync(PunchCorrectionRequest request, CancellationToken ct = default);

    /// <summary>添加打卡记录</summary>
    /// <param name="request">添加打卡记录请求</param>
    /// <param name="ct">取消令牌</param>
    Task AddCheckinDataAsync(AddCheckinDataRequest request, CancellationToken ct = default);

    /// <summary>获取设备打卡数据</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>设备打卡记录列表</returns>
    Task<DeviceCheckinDataItem[]> GetCheckinDeviceDataAsync(GetCheckinDeviceDataRequest request, CancellationToken ct = default);

    /// <summary>添加打卡规则</summary>
    /// <param name="request">添加打卡规则请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>新增规则 id</returns>
    Task<int> AddCheckinOptionAsync(AddCheckinOptionRequest request, CancellationToken ct = default);

    /// <summary>修改打卡规则</summary>
    /// <param name="request">修改打卡规则请求</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateCheckinOptionAsync(UpdateCheckinOptionRequest request, CancellationToken ct = default);

    /// <summary>清空打卡规则（删除指定规则下所有人员）</summary>
    /// <param name="groupId">打卡规则 id</param>
    /// <param name="ct">取消令牌</param>
    Task ClearCheckinOptionAsync(int groupId, CancellationToken ct = default);
}

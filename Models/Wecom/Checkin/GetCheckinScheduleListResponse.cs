using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>获取打卡人员排班信息响应</summary>
public class GetCheckinScheduleListResponse : WecomBaseResponse
{
    /// <summary>排班列表</summary>
    [JsonPropertyName("schedule_list")] public CheckinScheduleItem[]? ScheduleList { get; set; }
}


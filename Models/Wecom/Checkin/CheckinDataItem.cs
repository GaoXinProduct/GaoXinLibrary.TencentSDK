using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>打卡记录</summary>
public class CheckinDataItem
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>打卡规则名称</summary>
    [JsonPropertyName("groupname")] public string? GroupName { get; set; }

    /// <summary>打卡类型：上班打卡 / 下班打卡 / 外出打卡</summary>
    [JsonPropertyName("checkin_type")] public string? CheckinType { get; set; }

    /// <summary>异常类型：时间为空 / 地点或wifi为空</summary>
    [JsonPropertyName("exception_type")] public string? ExceptionType { get; set; }

    /// <summary>打卡时间（Unix 时间戳）</summary>
    [JsonPropertyName("checkin_time")] public long? CheckinTime { get; set; }

    /// <summary>打卡地点标题</summary>
    [JsonPropertyName("location_title")] public string? LocationTitle { get; set; }

    /// <summary>打卡地点详情</summary>
    [JsonPropertyName("location_detail")] public string? LocationDetail { get; set; }

    /// <summary>打卡 WiFi 名称</summary>
    [JsonPropertyName("wifiname")] public string? WifiName { get; set; }

    /// <summary>备注</summary>
    [JsonPropertyName("notes")] public string? Notes { get; set; }

    /// <summary>打卡 WiFi MAC 地址</summary>
    [JsonPropertyName("wifimac")] public string? WifiMac { get; set; }

    /// <summary>打卡的媒体 id 列表</summary>
    [JsonPropertyName("mediaids")] public string[]? MediaIds { get; set; }

    /// <summary>纬度</summary>
    [JsonPropertyName("lat")] public long? Lat { get; set; }

    /// <summary>经度</summary>
    [JsonPropertyName("lng")] public long? Lng { get; set; }

    /// <summary>设备号</summary>
    [JsonPropertyName("deviceid")] public string? DeviceId { get; set; }

    /// <summary>标准打卡时间（Unix 时间戳）</summary>
    [JsonPropertyName("sch_checkin_time")] public long? SchCheckinTime { get; set; }

    /// <summary>规则 id</summary>
    [JsonPropertyName("groupid")] public int? GroupId { get; set; }

    /// <summary>班次 id</summary>
    [JsonPropertyName("schedule_id")] public int? ScheduleId { get; set; }

    /// <summary>时段 id</summary>
    [JsonPropertyName("timeline_id")] public int? TimelineId { get; set; }
}


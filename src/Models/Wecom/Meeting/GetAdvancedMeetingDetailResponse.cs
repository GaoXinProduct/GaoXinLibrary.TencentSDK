using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取预约会议详情响应</summary>
/// <remarks>doc path: /98149</remarks>
public class GetAdvancedMeetingDetailResponse : WecomBaseResponse
{
    /// <summary>会议信息</summary>
    [JsonPropertyName("meeting_info")]
    public AdvancedMeetingDetailInfo? MeetingInfo { get; set; }
}

/// <summary>预约会议详情信息</summary>
public class AdvancedMeetingDetailInfo
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long MeetingEnd { get; set; }

    /// <summary>会议状态：0-未开始，1-正在进行，2-已结束，3-已取消</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>会议类型：0-普通会议，1-全员会议</summary>
    [JsonPropertyName("meeting_type")]
    public int MeetingType { get; set; }

    /// <summary>会议描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>组织名称</summary>
    [JsonPropertyName("org_name")]
    public string? OrgName { get; set; }

    /// <summary>会议主持人userid</summary>
    [JsonPropertyName("host_userid")]
    public string? HostUserId { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }

    /// <summary>入会链接</summary>
    [JsonPropertyName("join_url")]
    public string? JoinUrl { get; set; }

    /// <summary>会议密码</summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>会议地点</summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>会议设置</summary>
    [JsonPropertyName("settings")]
    public MeetingSettings? Settings { get; set; }

    /// <summary>是否自动开始录制</summary>
    [JsonPropertyName("auto_record")]
    public bool AutoRecord { get; set; }

    /// <summary>受邀成员列表</summary>
    [JsonPropertyName("invitees")]
    public List<MeetingInvitee>? Invitees { get; set; }
}
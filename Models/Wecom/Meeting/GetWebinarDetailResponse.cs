using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会详情响应</summary>
/// <remarks>doc path: /98860</remarks>
public class GetWebinarDetailResponse : WecomBaseResponse
{
    /// <summary>研讨会信息</summary>
    [JsonPropertyName("webinar_info")]
    public WebinarDetailInfo? WebinarInfo { get; set; }
}

/// <summary>网络研讨会详情信息</summary>
public class WebinarDetailInfo
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string? WebinarId { get; set; }

    /// <summary>研讨会号</summary>
    [JsonPropertyName("webinar_code")]
    public string? WebinarCode { get; set; }

    /// <summary>研讨会标题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>研讨会开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("webinar_start")]
    public long WebinarStart { get; set; }

    /// <summary>研讨会结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("webinar_end")]
    public long WebinarEnd { get; set; }

    /// <summary>研讨会状态：0-未开始，1-正在进行，2-已结束，3-已取消</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>研讨会描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>组织名称</summary>
    [JsonPropertyName("org_name")]
    public string? OrgName { get; set; }

    /// <summary>主持人userid</summary>
    [JsonPropertyName("host_userid")]
    public string? HostUserId { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }

    /// <summary>入会链接</summary>
    [JsonPropertyName("join_url")]
    public string? JoinUrl { get; set; }

    /// <summary>研讨会地点</summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>是否开启直播</summary>
    [JsonPropertyName("enable_live")]
    public bool EnableLive { get; set; }

    /// <summary>是否开启报名</summary>
    [JsonPropertyName("enable_registration")]
    public bool EnableRegistration { get; set; }

    /// <summary>是否开启联席主持人</summary>
    [JsonPropertyName("enable_cohost")]
    public bool EnableCohost { get; set; }
}
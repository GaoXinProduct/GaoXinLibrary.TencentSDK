using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>直播信息</summary>
public class LivingInfo
{
    /// <summary>直播ID</summary>
    [JsonPropertyName("livingid")] public string? LivingId { get; set; }

    /// <summary>直播主题</summary>
    [JsonPropertyName("theme")] public string? Theme { get; set; }

    /// <summary>直播开始时间（Unix时间戳）</summary>
    [JsonPropertyName("living_start")] public long LivingStart { get; set; }

    /// <summary>直播持续时长（秒）</summary>
    [JsonPropertyName("living_duration")] public long LivingDuration { get; set; }

    /// <summary>直播状态，0-预约中，1-直播中，2-已结束，3-已过期，4-已取消</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>直播类型，0-通用直播，1-小班课，2-大班课，3-企业培训，4-活动直播</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>主播userid</summary>
    [JsonPropertyName("anchor_userid")] public string? AnchorUserId { get; set; }

    /// <summary>直播描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }

    /// <summary>观看人数</summary>
    [JsonPropertyName("viewer_num")] public int ViewerNum { get; set; }

    /// <summary>评论数</summary>
    [JsonPropertyName("comment_num")] public int CommentNum { get; set; }
}

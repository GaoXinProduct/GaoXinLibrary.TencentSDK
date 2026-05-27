using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议健康度响应</summary>
/// <remarks>doc path: /98821</remarks>
public class GetMeetingHealthResponse : WecomBaseResponse
{
    /// <summary>会议健康度信息</summary>
    [JsonPropertyName("health_info")]
    public MeetingHealthInfo? HealthInfo { get; set; }
}

/// <summary>会议健康度信息</summary>
public class MeetingHealthInfo
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>综合评分：0-未知，1-差，2-中，3-良，4-优</summary>
    [JsonPropertyName("overall_score")]
    public int OverallScore { get; set; }

    /// <summary>视频流畅度评分：0-未知，1-差，2-中，3-良，4-优</summary>
    [JsonPropertyName("video_score")]
    public int VideoScore { get; set; }

    /// <summary>音频流畅度评分：0-未知，1-差，2-中，3-良，4-优</summary>
    [JsonPropertyName("audio_score")]
    public int AudioScore { get; set; }

    /// <summary>屏幕共享评分：0-未知，1-差，2-中，3-良，4-优</summary>
    [JsonPropertyName("screen_share_score")]
    public int ScreenShareScore { get; set; }

    /// <summary>网络延迟（毫秒）</summary>
    [JsonPropertyName("network_delay")]
    public int NetworkDelay { get; set; }

    /// <summary>丢包率（百分比）</summary>
    [JsonPropertyName("packet_loss_rate")]
    public double PacketLossRate { get; set; }

    /// <summary>网络状态：1-未知，2-极好，3-较好，4-一般，5-较差，6-极差</summary>
    [JsonPropertyName("network_status")]
    public int NetworkStatus { get; set; }
}
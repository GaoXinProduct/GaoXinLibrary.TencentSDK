using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议背景列表响应</summary>
/// <remarks>doc path: /98856</remarks>
public class GetMeetingBackgroundListResponse : WecomBaseResponse
{
    /// <summary>背景列表</summary>
    [JsonPropertyName("background_list")]
    public List<MeetingBackgroundInfo>? BackgroundList { get; set; }
}

/// <summary>会议背景信息</summary>
public class MeetingBackgroundInfo
{
    /// <summary>背景ID</summary>
    [JsonPropertyName("background_id")]
    public string? BackgroundId { get; set; }

    /// <summary>背景类型：1-图片，2-视频</summary>
    [JsonPropertyName("background_type")]
    public int BackgroundType { get; set; }

    /// <summary>背景URL</summary>
    [JsonPropertyName("background_url")]
    public string? BackgroundUrl { get; set; }

    /// <summary>背景名称</summary>
    [JsonPropertyName("background_name")]
    public string? BackgroundName { get; set; }

    /// <summary>是否为默认背景</summary>
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }
}
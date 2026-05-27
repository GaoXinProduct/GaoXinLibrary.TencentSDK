using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>关闭或开启成员视频请求</summary>
/// <remarks>doc path: /98189</remarks>
public record ManageVideoRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>操作类型：1-关闭视频，2-开启视频</summary>
    [JsonPropertyName("operate_type")]
    public int OperateType { get; init; }

    /// <summary>成员userid列表</summary>
    [JsonPropertyName("userid_list")]
    public List<string>? UserIdList { get; init; }
}
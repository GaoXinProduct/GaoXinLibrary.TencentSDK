using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>管理联席主持人请求</summary>
/// <remarks>doc path: /98180</remarks>
public record ManageCoHostRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>操作类型：1-添加，2-删除</summary>
    [JsonPropertyName("operate_type")]
    public int OperateType { get; init; }

    /// <summary>联席主持人userid列表</summary>
    [JsonPropertyName("cohost_userid_list")]
    public List<string> CohostUserIdList { get; init; } = new();
}
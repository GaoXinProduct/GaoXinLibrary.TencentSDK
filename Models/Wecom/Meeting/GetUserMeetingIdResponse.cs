using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取成员会议ID列表响应</summary>
public class GetUserMeetingIdResponse : WecomBaseResponse
{
    /// <summary>会议ID列表</summary>
    [JsonPropertyName("meeting_id_list")] public string[]? MeetingIdList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

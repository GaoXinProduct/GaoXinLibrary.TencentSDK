using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取成员会议ID列表响应</summary>
/// <remarks>doc path: /99050</remarks>
public class GetMeetingIdListResponse : WecomBaseResponse
{
    /// <summary>会议ID列表</summary>
    [JsonPropertyName("meeting_id_list")]
    public List<MeetingIdItem>? MeetingIdList { get; set; }

    /// <summary>分页游标（用于加载更多数据）</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>会议ID项</summary>
public class MeetingIdItem
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
}
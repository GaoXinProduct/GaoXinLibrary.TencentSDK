using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetPSTNMemberIdRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("nick_name")]
    public string? NickName { get; set; }

    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }
}

public sealed class GetPSTNMemberIdResponse : WecomBaseResponse
{
    [JsonPropertyName("member_id")]
    public string? MemberId { get; set; }

    [JsonPropertyName("member_type")]
    public int MemberType { get; set; }
}
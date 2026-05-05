using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class BatchCallRequest
{
    [JsonPropertyName("userids")]
    public List<string>? UserIds { get; set; }

    [JsonPropertyName("mobile_list")]
    public List<string>? MobileList { get; set; }

    [JsonPropertyName("call_type")]
    public int CallType { get; set; }

    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }
}

public sealed class BatchCallResponse : WecomBaseResponse
{
    [JsonPropertyName("results")]
    public List<CallResult>? Results { get; set; }
}

public sealed class CallResult
{
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
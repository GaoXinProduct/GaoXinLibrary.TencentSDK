using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetBatchCallStatusRequest
{
    [JsonPropertyName("callid")]
    public string CallId { get; set; } = string.Empty;
}

public sealed class GetBatchCallStatusResponse : WecomBaseResponse
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("call_list")]
    public List<CallDetail>? CallList { get; set; }
}

public sealed class CallDetail
{
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    [JsonPropertyName("call_status")]
    public int CallStatus { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}
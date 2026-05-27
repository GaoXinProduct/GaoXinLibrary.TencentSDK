
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentListRequest
{
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    [JsonPropertyName("filter_type")]
    public int? FilterType { get; set; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}

public sealed class MomentItem
{
    [JsonPropertyName("moment_id")]
    public string? MomentId { get; set; }

    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    [JsonPropertyName("create_type")]
    public int CreateType { get; set; }

    [JsonPropertyName("visible_type")]
    public int VisibleType { get; set; }

    [JsonPropertyName("text")]
    public MomentText? Text { get; set; }

    [JsonPropertyName("image")]
    public MomentMedia[]? Image { get; set; }

    [JsonPropertyName("video")]
    public MomentMedia? Video { get; set; }

    [JsonPropertyName("link")]
    public MomentLink? Link { get; set; }

    [JsonPropertyName("task_status")]
    public int TaskStatus { get; set; }

    [JsonPropertyName("publish_status")]
    public int PublishStatus { get; set; }

    [JsonPropertyName("send_time")]
    public long SendTime { get; set; }
}

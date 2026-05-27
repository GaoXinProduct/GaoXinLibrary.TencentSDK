using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentTaskResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("task_list")]
    public MomentTaskItem[]? TaskList { get; set; }
}

public sealed class MomentTaskItem
{
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("publish_status")]
    public int PublishStatus { get; set; }
}

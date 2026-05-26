using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>群发任务列表响应</summary>
public sealed class GetGroupmsgTaskResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("task_list")] public GroupMsgTask[]? TaskList { get; set; }
}

public sealed class GroupMsgTask
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("status")] public int Status { get; set; }
    [JsonPropertyName("send_time")] public long SendTime { get; set; }
}

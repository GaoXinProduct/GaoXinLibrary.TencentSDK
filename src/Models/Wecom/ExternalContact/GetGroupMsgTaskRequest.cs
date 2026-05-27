namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

using GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>获取群发消息发送任务列表请求</summary>
public sealed class GetGroupMsgTaskRequest
{
    /// <summary>群发消息 ID</summary>
    [JsonPropertyName("msgid")]
    public string MsgId { get; set; } = string.Empty;

    /// <summary>每页记录数（最大 500）</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 500;

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

/// <summary>获取群发消息发送任务列表响应</summary>
public sealed class GetGroupMsgTaskResponse : WecomBaseResponse
{
    /// <summary>下一页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>任务列表</summary>
    [JsonPropertyName("task_list")]
    public GroupMsgTaskItem[]? TaskList { get; set; }
}

/// <summary>群发消息任务项</summary>
public sealed class GroupMsgTaskItem
{
    /// <summary>成员 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>发送状态：0-未发送, 1-已发送, 2-发送失败</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>发送时间（Unix 时间戳）</summary>
    [JsonPropertyName("send_time")]
    public long SendTime { get; set; }
}

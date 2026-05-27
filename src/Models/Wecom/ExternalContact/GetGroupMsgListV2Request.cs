namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

using GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>获取群发消息列表请求</summary>
public sealed class GetGroupMsgListV2Request
{
    /// <summary>群发类型：single-发送给客户, group-发送给客户群</summary>
    [JsonPropertyName("chat_type")]
    public string ChatType { get; set; } = "single";

    /// <summary>查询起始时间（Unix 时间戳）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>查询结束时间（Unix 时间戳）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>创建人 userid</summary>
    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    /// <summary>过滤类型：1-所有, 2-创建成功, 3-创建失败, 4-已发送</summary>
    [JsonPropertyName("filter_type")]
    public int FilterType { get; set; } = 1;

    /// <summary>每页记录数（最大 500）</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 50;

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

/// <summary>获取群发消息列表响应</summary>
public sealed class GetGroupMsgListV2Response : WecomBaseResponse
{
    /// <summary>下一页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>群发消息列表</summary>
    [JsonPropertyName("group_msg_list")]
    public GroupMsgItem[]? GroupMsgList { get; set; }
}

/// <summary>群发消息列表项</summary>
public sealed class GroupMsgItem
{
    /// <summary>群发消息 ID</summary>
    [JsonPropertyName("msgid")]
    public string MsgId { get; set; } = string.Empty;

    /// <summary>创建人</summary>
    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    /// <summary>创建时间</summary>
    [JsonPropertyName("create_time")]
    public string? CreateTime { get; set; }

    /// <summary>创建方式：0-企业群发, 1-员工创建, 2-个人创建</summary>
    [JsonPropertyName("create_type")]
    public int CreateType { get; set; }

    /// <summary>文本消息内容</summary>
    [JsonPropertyName("text")]
    public GroupMsgText? Text { get; set; }
}

using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>群发记录列表响应</summary>
public sealed class GetGroupmsgListV2Response : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("group_msg_list")] public GroupMsgRecord[]? GroupMsgList { get; set; }
}

public sealed class GroupMsgRecord
{
    [JsonPropertyName("msgid")] public string MsgId { get; set; } = string.Empty;
    [JsonPropertyName("creator")] public string? Creator { get; set; }
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }
    [JsonPropertyName("create_type")] public int CreateType { get; set; }
    [JsonPropertyName("text")] public GroupMsgTextContent? Text { get; set; }
    [JsonPropertyName("attachments")] public GroupMsgAttachment[]? Attachments { get; set; }
}

public sealed class GroupMsgTextContent
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

public sealed class GroupMsgAttachment
{
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;
    [JsonPropertyName("image")] public GroupMsgImage? Image { get; set; }
    [JsonPropertyName("link")] public GroupMsgLink? Link { get; set; }
    [JsonPropertyName("miniprogram")] public GroupMsgMiniProgram? MiniProgram { get; set; }
}

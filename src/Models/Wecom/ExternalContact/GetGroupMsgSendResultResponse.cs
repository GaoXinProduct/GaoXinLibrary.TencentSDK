using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>群发发送结果响应</summary>
public sealed class GetGroupmsgSendResultResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("send_list")] public GroupMsgSendResult[]? SendList { get; set; }
}

public sealed class GroupMsgSendResult
{
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
    [JsonPropertyName("chat_id")] public string? ChatId { get; set; }
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("status")] public int Status { get; set; }
    [JsonPropertyName("send_time")] public long SendTime { get; set; }
}

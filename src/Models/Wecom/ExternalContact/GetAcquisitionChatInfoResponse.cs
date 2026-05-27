using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获客链接客户群信息响应</summary>
public sealed class GetAcquisitionChatInfoResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("chat_list")] public AcquisitionChatInfo[]? ChatList { get; set; }
}

public sealed class AcquisitionChatInfo
{
    [JsonPropertyName("chat_id")] public string ChatId { get; set; } = string.Empty;
    [JsonPropertyName("chat_name")] public string? ChatName { get; set; }
    [JsonPropertyName("member_num")] public int MemberNum { get; set; }
    [JsonPropertyName("external_member_num")] public int ExternalMemberNum { get; set; }
    [JsonPropertyName("member_list")] public AcquisitionChatMember[]? MemberList { get; set; }
}

public sealed class AcquisitionChatMember
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("join_time")] public long JoinTime { get; set; }
}

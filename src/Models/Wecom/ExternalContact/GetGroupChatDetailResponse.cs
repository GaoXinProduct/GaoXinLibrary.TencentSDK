using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>客户群详情响应</summary>
public sealed class GetGroupChatDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("group_chat")] public GroupChatDetailInfo? GroupChat { get; set; }
}

public sealed class GroupChatDetailInfo
{
    [JsonPropertyName("chat_id")] public string ChatId { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("owner")] public string? Owner { get; set; }
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }
    [JsonPropertyName("notice")] public string? Notice { get; set; }
    [JsonPropertyName("member_list")] public GroupChatMember[]? MemberList { get; set; }
    [JsonPropertyName("admin_list")] public GroupChatAdmin[]? AdminList { get; set; }
}

public sealed class GroupChatMember
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("join_time")] public long JoinTime { get; set; }
    [JsonPropertyName("join_scene")] public int JoinScene { get; set; }
    [JsonPropertyName("invitor")] public GroupChatInvitor? Invitor { get; set; }
    [JsonPropertyName("group_nickname")] public string? GroupNickname { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}

public sealed class GroupChatInvitor
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
}

public sealed class GroupChatAdmin
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
}

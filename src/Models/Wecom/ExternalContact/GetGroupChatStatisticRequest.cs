using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>群聊数据统计请求</summary>
public sealed class GetGroupChatStatisticRequest
{
    [JsonPropertyName("day_begin_time")] public long DayBeginTime { get; set; }
    [JsonPropertyName("day_end_time")] public long DayEndTime { get; set; }
    [JsonPropertyName("owner_filter")] public GroupChatOwnerFilter? OwnerFilter { get; set; }
    [JsonPropertyName("order_by")] public int OrderBy { get; set; }
    [JsonPropertyName("order_asc")] public int OrderAsc { get; set; }
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; } = 50;
}

/// <summary>群主筛选条件</summary>
public sealed class GroupChatOwnerFilter
{
    [JsonPropertyName("userid_list")] public string[]? UserIdList { get; set; }
    [JsonPropertyName("partyid_list")] public int[]? PartyIdList { get; set; }
}

/// <summary>群聊数据统计响应</summary>
public sealed class GetGroupChatStatisticResponse : WecomBaseResponse
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("next_offset")] public int NextOffset { get; set; }
    [JsonPropertyName("items")] public GroupChatStatisticItem[]? Items { get; set; }
}

/// <summary>群聊统计项</summary>
public sealed class GroupChatStatisticItem
{
    [JsonPropertyName("owner")] public string Owner { get; set; } = string.Empty;
    [JsonPropertyName("data")] public GroupChatStatisticData? Data { get; set; }
}

/// <summary>群聊统计数据</summary>
public sealed class GroupChatStatisticData
{
    [JsonPropertyName("new_chat_cnt")] public int NewChatCnt { get; set; }
    [JsonPropertyName("chat_total")] public int ChatTotal { get; set; }
    [JsonPropertyName("chat_has_msg")] public int ChatHasMsg { get; set; }
    [JsonPropertyName("new_member_cnt")] public int NewMemberCnt { get; set; }
    [JsonPropertyName("member_total")] public int MemberTotal { get; set; }
    [JsonPropertyName("member_has_msg")] public int MemberHasMsg { get; set; }
    [JsonPropertyName("msg_total")] public int MsgTotal { get; set; }
}

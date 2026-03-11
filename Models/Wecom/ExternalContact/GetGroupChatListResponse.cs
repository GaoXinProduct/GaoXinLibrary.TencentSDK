using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取客户群列表响应</summary>
public class GetGroupChatListResponse : WecomBaseResponse
{
    /// <summary>客户群列表</summary>
    [JsonPropertyName("group_chat_list")] public GroupChatItem[]? GroupChatList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

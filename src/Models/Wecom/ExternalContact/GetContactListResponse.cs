using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>已服务的外部联系人响应</summary>
public sealed class GetContactListResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("result_list")] public ContactListItem[]? ResultList { get; set; }
}

public sealed class ContactListItem
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("add_way")] public int AddWay { get; set; }
    [JsonPropertyName("oper_userid")] public string? OperUserId { get; set; }
    [JsonPropertyName("state")] public string? State { get; set; }
}

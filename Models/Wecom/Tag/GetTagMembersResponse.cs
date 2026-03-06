using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

public class GetTagMembersResponse : WecomBaseResponse
{
    [JsonPropertyName("tagname")] public string? TagName { get; set; }
    [JsonPropertyName("userlist")] public TagUserInfo[]? UserList { get; set; }
    [JsonPropertyName("partylist")] public int[]? PartyList { get; set; }
}


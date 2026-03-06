using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

/// <summary>增加/删除标签成员请求</summary>
public class TagMembersRequest
{
    [JsonPropertyName("tagid")] public int TagId { get; set; }
    [JsonPropertyName("userlist")] public string[]? UserList { get; set; }
    [JsonPropertyName("partylist")] public int[]? PartyList { get; set; }
}


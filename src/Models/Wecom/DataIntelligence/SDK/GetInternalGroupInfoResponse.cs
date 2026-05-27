using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetInternalGroupInfoResponse : WecomBaseResponse
{
    [JsonPropertyName("group_info")]
    public GroupInfo? GroupInfo { get; set; }
}

public class GroupInfo
{
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    [JsonPropertyName("room_name")]
    public string? RoomName { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    [JsonPropertyName("member_count")]
    public int MemberCount { get; set; }
}
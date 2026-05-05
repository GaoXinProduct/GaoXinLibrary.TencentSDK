using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;

public class GetPermitUserListResponse : WecomBaseResponse
{
    [JsonPropertyName("permit_user_list")]
    public PermitUser[]? PermitUserList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class PermitUser
{
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("permit_time")]
    public long PermitTime { get; set; }
}
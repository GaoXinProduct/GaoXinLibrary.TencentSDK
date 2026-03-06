using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>邀请成员响应</summary>
public class InviteMemberResponse : WecomBaseResponse
{
    /// <summary>非法成员列表</summary>
    [JsonPropertyName("invaliduser")] public string[]? InvalidUser { get; set; }

    /// <summary>非法部门列表</summary>
    [JsonPropertyName("invalidparty")] public int[]? InvalidParty { get; set; }

    /// <summary>非法标签列表</summary>
    [JsonPropertyName("invalidtag")] public int[]? InvalidTag { get; set; }
}


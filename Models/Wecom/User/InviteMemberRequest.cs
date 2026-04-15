using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

#region 邀请成员

/// <summary>邀请成员请求</summary>
public class InviteMemberRequest
{
    /// <summary>成员UserID列表，最多1000个</summary>
    [JsonPropertyName("user")] public string[]? User { get; set; }

    /// <summary>部门ID列表，最多100个</summary>
    [JsonPropertyName("party")] public int[]? Party { get; set; }

    /// <summary>标签ID列表，最多100个</summary>
    [JsonPropertyName("tag")] public int[]? Tag { get; set; }
}

#endregion

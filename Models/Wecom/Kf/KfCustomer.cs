using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>客服客户信息</summary>
public class KfCustomer
{
    /// <summary>微信客户的 external_userid</summary>
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>微信昵称</summary>
    [JsonPropertyName("nickname")] public string? Nickname { get; set; }

    /// <summary>微信头像</summary>
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }

    /// <summary>性别</summary>
    [JsonPropertyName("gender")] public int Gender { get; set; }

    /// <summary>unionid（需要对应开放平台有绑定关系）</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }

    /// <summary>进入会话的场景值</summary>
    [JsonPropertyName("enter_session_context")] public KfEnterSessionContext? EnterSessionContext { get; set; }
}


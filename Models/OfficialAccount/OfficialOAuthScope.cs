using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>OAuth 授权作用域</summary>
public static class OfficialOAuthScope
{
    /// <summary>静默授权，仅获取 OpenId</summary>
    public const string Base = "snsapi_base";

    /// <summary>手动授权，可获取用户信息</summary>
    public const string UserInfo = "snsapi_userinfo";
}


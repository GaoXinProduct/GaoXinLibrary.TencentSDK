using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

// ─── 授权范围 ──────────────────────────────────────────────────────────────

/// <summary>
/// 网页授权作用域
/// </summary>
public static class OAuthScope
{
    /// <summary>
    /// 静默授权，不弹出授权页面，用户无感知；
    /// 可获取成员 UserId（需成员已关注企业号或在应用可见范围内）
    /// </summary>
    public const string Base = "snsapi_base";

    /// <summary>
    /// 手动授权，弹出授权确认页面；
    /// 可获取成员的敏感信息（姓名、手机、邮箱等），需要成员同意
    /// </summary>
    public const string PrivateInfo = "snsapi_privateinfo";
}


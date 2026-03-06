using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 拉取用户信息响应（GET /sns/userinfo）
/// </summary>
public class OAuthUserInfoResponse : WechatBaseResponse
{
    /// <summary>用户唯一标识</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>用户昵称</summary>
    [JsonPropertyName("nickname")] public string? Nickname { get; set; }

    /// <summary>用户性别（1 男，2 女，0 未知）</summary>
    [JsonPropertyName("sex")] public int Sex { get; set; }

    /// <summary>省份</summary>
    [JsonPropertyName("province")] public string? Province { get; set; }

    /// <summary>城市</summary>
    [JsonPropertyName("city")] public string? City { get; set; }

    /// <summary>国家</summary>
    [JsonPropertyName("country")] public string? Country { get; set; }

    /// <summary>用户头像 URL</summary>
    [JsonPropertyName("headimgurl")] public string? HeadImgUrl { get; set; }

    /// <summary>用户特权信息（JSON 数组）</summary>
    [JsonPropertyName("privilege")] public List<string>? Privilege { get; set; }

    /// <summary>只有在用户将公众号绑定到微信开放平台时才有</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}


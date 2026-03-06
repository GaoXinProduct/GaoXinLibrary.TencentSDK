using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

/// <summary>
/// 获取用户个人信息响应（GET /sns/userinfo）
/// </summary>
public class OpenUserInfoResponse : WechatBaseResponse
{
    /// <summary>普通用户的标识</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>普通用户昵称</summary>
    [JsonPropertyName("nickname")] public string? Nickname { get; set; }

    /// <summary>普通用户性别（1 男，2 女）</summary>
    [JsonPropertyName("sex")] public int Sex { get; set; }

    /// <summary>省份</summary>
    [JsonPropertyName("province")] public string? Province { get; set; }

    /// <summary>城市</summary>
    [JsonPropertyName("city")] public string? City { get; set; }

    /// <summary>国家（如 CN）</summary>
    [JsonPropertyName("country")] public string? Country { get; set; }

    /// <summary>用户头像 URL</summary>
    [JsonPropertyName("headimgurl")] public string? HeadImgUrl { get; set; }

    /// <summary>用户特权信息</summary>
    [JsonPropertyName("privilege")] public List<string>? Privilege { get; set; }

    /// <summary>用户统一标识</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}


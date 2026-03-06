using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

// ─── 获取用户信息 ────────────────────────────────────────────────────────

/// <summary>
/// 获取 QQ 用户信息响应
/// <para>
/// 对应接口：GET https://graph.qq.com/user/get_user_info
/// </para>
/// </summary>
public class QQUserInfoResponse : QQOpenApiBaseResponse
{
    /// <summary>用户昵称</summary>
    [JsonPropertyName("nickname")] public string? Nickname { get; set; }

    /// <summary>大小为 30×30 像素的 QQ 空间头像 URL</summary>
    [JsonPropertyName("figureurl")] public string? FigureUrl { get; set; }

    /// <summary>大小为 50×50 像素的 QQ 空间头像 URL</summary>
    [JsonPropertyName("figureurl_1")] public string? FigureUrl1 { get; set; }

    /// <summary>大小为 100×100 像素的 QQ 空间头像 URL</summary>
    [JsonPropertyName("figureurl_2")] public string? FigureUrl2 { get; set; }

    /// <summary>大小为 40×40 像素的 QQ 头像 URL</summary>
    [JsonPropertyName("figureurl_qq_1")] public string? FigureUrlQQ1 { get; set; }

    /// <summary>大小为 100×100 像素的 QQ 头像 URL（不一定有）</summary>
    [JsonPropertyName("figureurl_qq_2")] public string? FigureUrlQQ2 { get; set; }

    /// <summary>性别（男 / 女 / 空字符串）</summary>
    [JsonPropertyName("gender")] public string? Gender { get; set; }

    /// <summary>性别类型（1 男，2 女，0 未设置）</summary>
    [JsonPropertyName("gender_type")] public int GenderType { get; set; }

    /// <summary>省份</summary>
    [JsonPropertyName("province")] public string? Province { get; set; }

    /// <summary>城市</summary>
    [JsonPropertyName("city")] public string? City { get; set; }

    /// <summary>年份</summary>
    [JsonPropertyName("year")] public string? Year { get; set; }

    /// <summary>星座</summary>
    [JsonPropertyName("constellation")] public string? Constellation { get; set; }

    /// <summary>是否黄钻用户（true / false）</summary>
    [JsonPropertyName("is_yellow_vip")] public string? IsYellowVip { get; set; }

    /// <summary>是否黄钻年费用户</summary>
    [JsonPropertyName("is_yellow_year_vip")] public string? IsYellowYearVip { get; set; }

    /// <summary>黄钻等级</summary>
    [JsonPropertyName("yellow_vip_level")] public string? YellowVipLevel { get; set; }

    /// <summary>VIP 信息标识</summary>
    [JsonPropertyName("vip")] public string? Vip { get; set; }

    /// <summary>QQ 等级</summary>
    [JsonPropertyName("level")] public string? Level { get; set; }
}


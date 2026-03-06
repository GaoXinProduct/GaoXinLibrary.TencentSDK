using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取用户基本信息响应（GET /cgi-bin/user/info）
/// </summary>
public class UserInfoResponse : WechatBaseResponse
{
    /// <summary>用户是否订阅该公众号（0 未关注，1 已关注）</summary>
    [JsonPropertyName("subscribe")] public int Subscribe { get; set; }

    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>用户语言</summary>
    [JsonPropertyName("language")] public string? Language { get; set; }

    /// <summary>用户关注时间（时间戳）</summary>
    [JsonPropertyName("subscribe_time")] public long SubscribeTime { get; set; }

    /// <summary>UnionId（绑定开放平台时）</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }

    /// <summary>公众号运营者对粉丝的备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }

    /// <summary>用户所在的分组 ID（兼容旧接口）</summary>
    [JsonPropertyName("groupid")] public int GroupId { get; set; }

    /// <summary>用户被打上的标签 ID 列表</summary>
    [JsonPropertyName("tagid_list")] public List<int>? TagIdList { get; set; }

    /// <summary>关注的渠道来源</summary>
    [JsonPropertyName("subscribe_scene")] public string? SubscribeScene { get; set; }

    /// <summary>
    /// 关注来源的中文显示名称（只读）
    /// <para>基于 <see cref="SubscribeScene"/> 自动转换，未知值直接返回原始值。</para>
    /// </summary>
    [JsonIgnore]
    public string SubscribeSceneDisplayName => Models.OfficialAccount.SubscribeScene.GetDisplayName(SubscribeScene);

    /// <summary>二维码扫码场景（关注渠道为扫描二维码时返回）</summary>
    [JsonPropertyName("qr_scene")] public int QrScene { get; set; }

    /// <summary>二维码扫码场景描述</summary>
    [JsonPropertyName("qr_scene_str")] public string? QrSceneStr { get; set; }
}


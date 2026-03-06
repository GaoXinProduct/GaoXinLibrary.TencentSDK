using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 用户关注公众号的渠道来源常量
/// <para>对应 <see cref="UserInfoResponse.SubscribeScene"/> 字段的可选值。</para>
/// </summary>
public static class SubscribeScene
{
    /// <summary>公众号搜索</summary>
    public const string Search = "ADD_SCENE_SEARCH";

    /// <summary>公众号迁移</summary>
    public const string AccountMigration = "ADD_SCENE_ACCOUNT_MIGRATION";

    /// <summary>名片分享</summary>
    public const string ProfileCard = "ADD_SCENE_PROFILE_CARD";

    /// <summary>扫描二维码</summary>
    public const string QrCode = "ADD_SCENE_QR_CODE";

    /// <summary>图文页内名称点击</summary>
    public const string ProfileLink = "ADD_SCENE_PROFILE_LINK";

    /// <summary>图文页右上角菜单</summary>
    public const string ProfileItem = "ADD_SCENE_PROFILE_ITEM";

    /// <summary>支付后关注</summary>
    public const string Paid = "ADD_SCENE_PAID";

    /// <summary>微信广告</summary>
    public const string WechatAdvertisement = "ADD_SCENE_WECHAT_ADVERTISEMENT";

    /// <summary>他人转载</summary>
    public const string Reprint = "ADD_SCENE_REPRINT";

    /// <summary>视频号直播</summary>
    public const string LiveStream = "ADD_SCENE_LIVESTREAM";

    /// <summary>视频号</summary>
    public const string Channels = "ADD_SCENE_CHANNELS";

    /// <summary>小程序关注</summary>
    public const string Wxa = "ADD_SCENE_WXA";

    /// <summary>其他</summary>
    public const string Others = "ADD_SCENE_OTHERS";

    private static readonly Dictionary<string, string> DisplayNames = new()
    {
        [Search] = "公众号搜索",
        [AccountMigration] = "公众号迁移",
        [ProfileCard] = "名片分享",
        [QrCode] = "扫描二维码",
        [ProfileLink] = "图文页内名称点击",
        [ProfileItem] = "图文页右上角菜单",
        [Paid] = "支付后关注",
        [WechatAdvertisement] = "微信广告",
        [Reprint] = "他人转载",
        [LiveStream] = "视频号直播",
        [Channels] = "视频号",
        [Wxa] = "小程序关注",
        [Others] = "其他",
    };

    /// <summary>
    /// 获取关注来源的中文显示名称
    /// <para>若传入值不在已知枚举中，则直接返回原始值。</para>
    /// </summary>
    /// <param name="scene">关注来源枚举值（如 ADD_SCENE_QR_CODE）</param>
    /// <returns>中文显示名称，或原始值</returns>
    public static string GetDisplayName(string? scene)
        => scene is not null && DisplayNames.TryGetValue(scene, out var name) ? name : scene ?? string.Empty;
}


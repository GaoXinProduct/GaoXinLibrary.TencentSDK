using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>菜单按钮</summary>
public class MenuButton
{
    /// <summary>菜单标题，不超过 16 字节（子菜单不超过 60 字节）</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }

    /// <summary>
    /// 菜单响应类型：click/view/scancode_push/scancode_waitmsg/pic_sysphoto
    /// /pic_photo_or_album/pic_weixin/location_select/media_id/article_id/article_view_limited/miniprogram
    /// </summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>click 类型必须，key 值用于消息推送（128 字节以内）</summary>
    [JsonPropertyName("key")] public string? Key { get; set; }

    /// <summary>view / miniprogram 类型必须，网页链接</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>media_id 类型必须，调用新增永久素材获取</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }

    /// <summary>article_id 类型必须</summary>
    [JsonPropertyName("article_id")] public string? ArticleId { get; set; }

    /// <summary>miniprogram 类型必须，小程序 AppId</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>miniprogram 类型必须，小程序页面路径</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }

    /// <summary>二级菜单数组，最多 5 个</summary>
    [JsonPropertyName("sub_button")] public List<MenuButton>? SubButton { get; set; }
}


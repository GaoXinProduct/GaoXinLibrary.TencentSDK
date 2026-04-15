using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

#region 菜单按钮

/// <summary>自定义菜单按钮</summary>
public class MenuButton
{
    /// <summary>
    /// 菜单按钮类型：
    /// click=点击推事件 / view=跳转URL / scancode_push=扫码推事件 /
    /// scancode_waitmsg=扫码带提示 / pic_sysphoto=系统拍照 / pic_photo_or_album=相册 /
    /// pic_weixin=微信相册 / location_select=发送位置 / view_miniprogram=跳转小程序
    /// </summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>菜单按钮名称，不超过16个字节</summary>
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

    /// <summary>菜单按钮 KEY（click 类型时必须）</summary>
    [JsonPropertyName("key")] public string? Key { get; set; }

    /// <summary>网页链接（view/view_miniprogram 类型时必须）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>小程序 appid（view_miniprogram 时必须）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>小程序页面路径（view_miniprogram 时必须）</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }

    /// <summary>子菜单按钮列表（最多5个，有子菜单时不能设置 type/key/url）</summary>
    [JsonPropertyName("sub_button")] public MenuButton[]? SubButton { get; set; }
}

#endregion

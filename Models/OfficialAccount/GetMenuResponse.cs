using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取自定义菜单响应（GET /cgi-bin/menu/get）
/// </summary>
public class GetMenuResponse : WechatBaseResponse
{
    /// <summary>菜单信息</summary>
    [JsonPropertyName("menu")] public MenuInfo? Menu { get; set; }
}


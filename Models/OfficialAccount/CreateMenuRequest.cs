using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建自定义菜单请求（POST /cgi-bin/menu/create）
/// </summary>
public class CreateMenuRequest
{
    /// <summary>一级菜单数组，最多 3 个</summary>
    [JsonPropertyName("button")] public required List<MenuButton> Button { get; set; }
}


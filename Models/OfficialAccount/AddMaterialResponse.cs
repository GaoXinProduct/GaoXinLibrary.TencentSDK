using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>新增永久素材响应（POST /cgi-bin/material/add_material）</summary>
public class AddMaterialResponse : WechatBaseResponse
{
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
}


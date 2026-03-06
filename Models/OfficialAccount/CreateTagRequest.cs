using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>创建标签请求（POST /cgi-bin/tags/create）</summary>
public class CreateTagRequest
{
    [JsonPropertyName("tag")] public required TagItem Tag { get; set; }
}


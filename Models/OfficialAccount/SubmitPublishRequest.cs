using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>发布草稿请求（POST /cgi-bin/freepublish/submit）</summary>
public sealed class SubmitPublishRequest
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
}


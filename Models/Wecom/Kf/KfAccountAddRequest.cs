using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>添加客服账号请求</summary>
public class KfAccountAddRequest
{
    /// <summary>客服名称，不超过16个字符</summary>
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

    /// <summary>客服头像的 media_id</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
}


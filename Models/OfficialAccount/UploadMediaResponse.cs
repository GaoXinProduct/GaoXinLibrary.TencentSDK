using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 上传临时素材响应（POST /cgi-bin/media/upload）
/// </summary>
public class UploadMediaResponse : WechatBaseResponse
{
    /// <summary>媒体文件类型（image/voice/video/thumb）</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>媒体文件上传后的标识</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }

    /// <summary>媒体文件上传时间戳</summary>
    [JsonPropertyName("created_at")] public long CreatedAt { get; set; }
}


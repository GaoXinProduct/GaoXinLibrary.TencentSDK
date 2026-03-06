using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// OCR 通用请求（POST /cv/ocr/*）
/// <para>img_url 与 img 二选一。</para>
/// </summary>
public class OcrRequest
{
    /// <summary>图片 URL（img_url 和 img 二选一）</summary>
    [JsonPropertyName("img_url")] public string? ImgUrl { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>OCR — 身份证识别请求（POST /cv/ocr/idcard）</summary>
public class OfficialOcrRequest
{
    /// <summary>图片 url（与 img_url 二选一）</summary>
    [JsonPropertyName("img_url")] public string? ImgUrl { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>OCR 识别项</summary>
public class OcrCommItem
{
    /// <summary>识别出的文本</summary>
    [JsonPropertyName("text")] public string? Text { get; set; }
    /// <summary>位置信息</summary>
    [JsonPropertyName("pos")] public OcrPosition? Pos { get; set; }
}


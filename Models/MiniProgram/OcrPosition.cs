using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>OCR 位置</summary>
public class OcrPosition
{
    [JsonPropertyName("left_top")] public OcrPoint? LeftTop { get; set; }
    [JsonPropertyName("right_top")] public OcrPoint? RightTop { get; set; }
    [JsonPropertyName("right_bottom")] public OcrPoint? RightBottom { get; set; }
    [JsonPropertyName("left_bottom")] public OcrPoint? LeftBottom { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>通用印刷体 OCR 响应（POST /cv/ocr/comm）</summary>
public class OcrCommResponse : WechatBaseResponse
{
    /// <summary>识别到的文本列表</summary>
    [JsonPropertyName("items")] public List<OcrCommItem>? Items { get; set; }
    /// <summary>图片大小</summary>
    [JsonPropertyName("img_size")] public OcrImageSize? ImgSize { get; set; }
}


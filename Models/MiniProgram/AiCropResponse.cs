using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>图片智能裁切响应（POST /cv/img/aicrop）</summary>
public class AiCropResponse : WechatBaseResponse
{
    /// <summary>裁切结果列表</summary>
    [JsonPropertyName("results")] public List<AiCropResult>? Results { get; set; }
    /// <summary>图片大小</summary>
    [JsonPropertyName("img_size")] public OcrImageSize? ImgSize { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>裁切结果</summary>
public class AiCropResult
{
    [JsonPropertyName("crop_left")] public int CropLeft { get; set; }
    [JsonPropertyName("crop_top")] public int CropTop { get; set; }
    [JsonPropertyName("crop_right")] public int CropRight { get; set; }
    [JsonPropertyName("crop_bottom")] public int CropBottom { get; set; }
}


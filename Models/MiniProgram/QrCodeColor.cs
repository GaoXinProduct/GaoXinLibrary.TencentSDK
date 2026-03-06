using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>小程序码颜色</summary>
public class QrCodeColor
{
    /// <summary>Red 分量 0-255</summary>
    [JsonPropertyName("r")] public int R { get; set; }

    /// <summary>Green 分量 0-255</summary>
    [JsonPropertyName("g")] public int G { get; set; }

    /// <summary>Blue 分量 0-255</summary>
    [JsonPropertyName("b")] public int B { get; set; }
}


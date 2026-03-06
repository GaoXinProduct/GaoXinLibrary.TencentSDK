using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取小程序码请求（POST /wxa/getwxacode）
/// </summary>
public class GetQrCodeRequest
{
    /// <summary>扫码进入的小程序页面路径，最大长度 1024 字节</summary>
    [JsonPropertyName("path")] public required string Path { get; set; }

    /// <summary>二维码宽度（单位 px），默认 430px</summary>
    [JsonPropertyName("width")] public int? Width { get; set; }

    /// <summary>自动配置线条颜色，默认 false</summary>
    [JsonPropertyName("auto_color")] public bool? AutoColor { get; set; }

    /// <summary>自定义颜色</summary>
    [JsonPropertyName("line_color")] public QrCodeColor? LineColor { get; set; }

    /// <summary>是否需要透明底色，默认 false</summary>
    [JsonPropertyName("is_hyaline")] public bool? IsHyaline { get; set; }

    /// <summary>环境版本：release/trial/develop，默认 release</summary>
    [JsonPropertyName("env_version")] public string? EnvVersion { get; set; }
}


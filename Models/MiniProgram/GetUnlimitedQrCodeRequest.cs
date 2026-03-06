using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取不限制的小程序码请求（POST /wxa/getwxacodeunlimit）
/// </summary>
public class GetUnlimitedQrCodeRequest
{
    /// <summary>最大32个可见字符，只支持数字、大小写字母以及部分特殊字符</summary>
    [JsonPropertyName("scene")] public required string Scene { get; set; }

    /// <summary>页面路径，根路径前不要填加 /，不能携带参数</summary>
    [JsonPropertyName("page")] public string? Page { get; set; }

    /// <summary>检查 page 是否存在，默认 true</summary>
    [JsonPropertyName("check_path")] public bool? CheckPath { get; set; }

    /// <summary>环境版本：release/trial/develop，默认 release</summary>
    [JsonPropertyName("env_version")] public string? EnvVersion { get; set; }

    /// <summary>二维码的宽度（单位 px），最小 280px，最大 1280px，默认 430px</summary>
    [JsonPropertyName("width")] public int? Width { get; set; }

    /// <summary>自动配置线条颜色，默认 false</summary>
    [JsonPropertyName("auto_color")] public bool? AutoColor { get; set; }

    /// <summary>line_color 生效前提：auto_color 为 false</summary>
    [JsonPropertyName("line_color")] public QrCodeColor? LineColor { get; set; }

    /// <summary>是否需要透明底色，默认 false</summary>
    [JsonPropertyName("is_hyaline")] public bool? IsHyaline { get; set; }
}


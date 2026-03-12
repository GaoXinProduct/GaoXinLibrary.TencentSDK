using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 二维码跳转规则项
/// </summary>
public class QrcodeJumpRuleItem
{
    /// <summary>二维码规则前缀</summary>
    [JsonPropertyName("prefix")] public string? Prefix { get; set; }

    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("path")] public string? Path { get; set; }

    /// <summary>规则发布状态，1 未发布，2 已发布</summary>
    [JsonPropertyName("state")] public int? State { get; set; }

    /// <summary>测试范围</summary>
    [JsonPropertyName("open_version")] public int? OpenVersion { get; set; }

    /// <summary>测试链接</summary>
    [JsonPropertyName("debug_url")] public List<string>? DebugUrl { get; set; }
}

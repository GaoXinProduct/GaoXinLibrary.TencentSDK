using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 增加或修改二维码规则请求
/// </summary>
public class QrcodeJumpAddRequest
{
    /// <summary>二维码规则前缀</summary>
    [JsonPropertyName("prefix")] public required string Prefix { get; set; }

    /// <summary>服务号二维码跳转小程序 appid（服务号场景）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>小程序功能页面</summary>
    [JsonPropertyName("path")] public required string Path { get; set; }

    /// <summary>编辑标记，0 新增，1 修改</summary>
    [JsonPropertyName("is_edit")] public int IsEdit { get; set; }

    /// <summary>测试范围（普通二维码场景）</summary>
    [JsonPropertyName("open_version")] public int? OpenVersion { get; set; }

    /// <summary>测试链接（普通二维码场景）</summary>
    [JsonPropertyName("debug_url")] public List<string>? DebugUrl { get; set; }

    /// <summary>子规则占用标记（普通二维码场景）</summary>
    [JsonPropertyName("permit_sub_rule")] public int? PermitSubRule { get; set; }
}

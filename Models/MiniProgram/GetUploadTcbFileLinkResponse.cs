using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取文件上传链接响应
/// </summary>
public sealed class GetUploadTcbFileLinkResponse : WechatBaseResponse
{
    /// <summary>上传链接</summary>
    [JsonPropertyName("url")] public string? Url { get; init; }
    /// <summary>token</summary>
    [JsonPropertyName("token")] public string? Token { get; init; }
    /// <summary>Authorization</summary>
    [JsonPropertyName("authorization")] public string? Authorization { get; init; }
}
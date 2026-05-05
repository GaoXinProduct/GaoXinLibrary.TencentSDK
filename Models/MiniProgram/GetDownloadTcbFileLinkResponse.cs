using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取文件下载链接响应
/// </summary>
public sealed class GetDownloadTcbFileLinkResponse : WechatBaseResponse
{
    [JsonPropertyName("url")] public string? Url { get; init; }
}
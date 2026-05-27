using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取文件下载链接请求（POST /tcb/download_file）
/// </summary>
public sealed class GetDownloadTcbFileLinkRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("path")] public required string Path { get; set; }
}
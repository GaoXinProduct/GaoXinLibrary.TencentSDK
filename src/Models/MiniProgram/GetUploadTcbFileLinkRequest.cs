using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取文件上传链接请求（POST /tcb/upload_file）
/// </summary>
public sealed class GetUploadTcbFileLinkRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    /// <summary>云存储路径</summary>
    [JsonPropertyName("path")] public required string Path { get; set; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 删除文件请求（POST /tcb/delete_file）
/// </summary>
public sealed class DeleteTcbCloudFileRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    /// <summary>文件路径列表</summary>
    [JsonPropertyName("file_list")] public required List<string> FileList { get; set; }
}
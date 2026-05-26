
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>重命名文件请求</summary>
public sealed class RenameFileRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>新文件名</summary>
    [JsonPropertyName("new_name")]
    public string NewName { get; set; } = string.Empty;
}

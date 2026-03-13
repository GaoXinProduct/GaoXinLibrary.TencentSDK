using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>创建文件请求</summary>
public class CreateFileRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string SpaceId { get; set; } = string.Empty;

    /// <summary>父目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public string FatherId { get; set; } = string.Empty;

    /// <summary>文件类型</summary>
    [JsonPropertyName("file_type")]
    public int FileType { get; set; }

    /// <summary>文件名称</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
}

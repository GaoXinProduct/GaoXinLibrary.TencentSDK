using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>移动文件请求</summary>
public class MoveFileRequest
{
    /// <summary>文件 ID 列表</summary>
    [JsonPropertyName("fileid")]
    public string[] FileIds { get; set; } = [];

    /// <summary>目标目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public string FatherId { get; set; } = string.Empty;
}

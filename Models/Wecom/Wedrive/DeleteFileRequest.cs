using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>删除文件请求</summary>
public class DeleteFileRequest
{
    /// <summary>文件 ID 列表</summary>
    [JsonPropertyName("fileid")]
    public string[] FileIds { get; set; } = [];
}

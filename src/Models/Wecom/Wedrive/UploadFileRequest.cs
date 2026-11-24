using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>上传文件请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97880</remarks>
public record UploadFileRequest
{
    /// <summary>空间 ID，与父目录 ID 一起使用，或改用选择凭证</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; init; }

    /// <summary>父目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public string? FatherId { get; init; }

    /// <summary>选中的微盘位置凭证</summary>
    [JsonPropertyName("selected_ticket")]
    public string? SelectedTicket { get; init; }

    /// <summary>文件名称</summary>
    [JsonPropertyName("file_name")]
    public required string FileName { get; init; }

    /// <summary>原始文件内容，序列化为 Base64</summary>
    [JsonPropertyName("file_base64_content")]
    public byte[]? FileContent { get; init; }

    /// <summary>旧模型的上传者字段</summary>
    [Obsolete("微盘上传接口通过应用凭证授权。")]
    [JsonIgnore]
    public string? UploadUserId { get; init; }
}

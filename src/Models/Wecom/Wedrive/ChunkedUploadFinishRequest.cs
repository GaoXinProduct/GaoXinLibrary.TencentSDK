using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传完成请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public record ChunkedUploadFinishRequest
{
    /// <summary>初始化返回的上传凭证</summary>
    [JsonPropertyName("upload_key")]
    public string? UploadKey { get; init; }

    /// <summary>上传凭证的兼容名称</summary>
    [JsonIgnore]
    public string? JobId { get => UploadKey; init => UploadKey = value; }
}

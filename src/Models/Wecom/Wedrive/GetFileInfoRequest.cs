using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件信息请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97886</remarks>
public record GetFileInfoRequest
{
    /// <summary>文件 ID 列表</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }
}
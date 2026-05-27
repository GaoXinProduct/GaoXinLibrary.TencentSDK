using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>新建文件夹/文档响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97882</remarks>
public class CreateFolderResponse : WecomBaseResponse
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public string? FileId { get; set; }

    /// <summary>文档 url（仅创建文档时返回）</summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
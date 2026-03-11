using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>创建文件夹/文档响应</summary>
public class CreateFileResponse : WecomBaseResponse
{
    /// <summary>文件ID</summary>
    [JsonPropertyName("fileid")] public string? FileId { get; set; }

    /// <summary>文档url（仅创建文档时返回）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }
}

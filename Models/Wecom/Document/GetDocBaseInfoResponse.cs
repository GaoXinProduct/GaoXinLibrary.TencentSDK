using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>获取文档基础信息响应</summary>
public class GetDocBaseInfoResponse : WecomBaseResponse
{
    /// <summary>文档信息</summary>
    [JsonPropertyName("doc_base_info")] public DocBaseInfo? DocBaseInfo { get; set; }
}

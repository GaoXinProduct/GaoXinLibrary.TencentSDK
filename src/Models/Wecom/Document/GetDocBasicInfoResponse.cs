using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>获取文档基础信息响应</summary>
public class GetDocBasicInfoResponse : WecomBaseResponse
{
    /// <summary>文档基础信息</summary>
    [JsonPropertyName("basic_info")] public DocBasicInfo? BasicInfo { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>创建收集表响应</summary>
public class CreateCollectFormResponse : WecomBaseResponse
{
    /// <summary>收集表ID</summary>
    [JsonPropertyName("formid")] public string? FormId { get; set; }

    /// <summary>收集表URL</summary>
    [JsonPropertyName("form_url")] public string? FormUrl { get; set; }
}

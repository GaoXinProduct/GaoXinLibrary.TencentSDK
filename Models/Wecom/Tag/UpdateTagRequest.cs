using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

/// <summary>更新标签请求</summary>
public class UpdateTagRequest
{
    [JsonPropertyName("tagid")] public int TagId { get; set; }
    [JsonPropertyName("tagname")] public string TagName { get; set; } = string.Empty;
}


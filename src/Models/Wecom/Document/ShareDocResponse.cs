using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>分享文档响应</summary>
public class ShareDocResponse : WecomBaseResponse
{
    /// <summary>文档分享链接</summary>
    [JsonPropertyName("share_url")] public string? ShareUrl { get; set; }
}

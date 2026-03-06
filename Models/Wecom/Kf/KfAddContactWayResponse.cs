using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取客服账号链接响应</summary>
public class KfAddContactWayResponse : WecomBaseResponse
{
    /// <summary>客服链接，开发者可将该链接嵌入到网页等场景中</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
}


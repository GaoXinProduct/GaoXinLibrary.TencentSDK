using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取客服账号链接请求</summary>
public class KfAddContactWayRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>场景值，64位整型</summary>
    [JsonPropertyName("scene")] public string? Scene { get; set; }
}


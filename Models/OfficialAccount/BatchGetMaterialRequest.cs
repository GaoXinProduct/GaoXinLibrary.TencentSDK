using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取素材列表请求（POST /cgi-bin/material/batchget_material）</summary>
public class BatchGetMaterialRequest
{
    /// <summary>素材类型（image/video/voice/news）</summary>
    [JsonPropertyName("type")] public required string Type { get; set; }
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; } = 20;
}


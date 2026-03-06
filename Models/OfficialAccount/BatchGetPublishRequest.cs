using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取成功发布列表请求（POST /cgi-bin/freepublish/batchget）</summary>
public class BatchGetPublishRequest
{
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; } = 20;
    [JsonPropertyName("no_content")] public int NoContent { get; set; }
}


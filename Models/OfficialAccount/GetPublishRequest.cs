using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询发布状态请求（POST /cgi-bin/freepublish/get）</summary>
public class GetPublishRequest
{
    [JsonPropertyName("publish_id")] public required string PublishId { get; set; }
}


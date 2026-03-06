using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取草稿请求（POST /cgi-bin/draft/get）</summary>
public class GetDraftRequest
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
}


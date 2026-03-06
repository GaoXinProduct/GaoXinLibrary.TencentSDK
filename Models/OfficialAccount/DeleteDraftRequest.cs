using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除草稿请求（POST /cgi-bin/draft/delete）</summary>
public class DeleteDraftRequest
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
}


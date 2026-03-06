using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>新建草稿请求（POST /cgi-bin/draft/add）</summary>
public class AddDraftRequest
{
    [JsonPropertyName("articles")] public required List<DraftArticle> Articles { get; set; }
}


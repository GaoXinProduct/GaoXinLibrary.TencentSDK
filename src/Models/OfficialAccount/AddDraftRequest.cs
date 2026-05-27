using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>新建草稿请求（POST /cgi-bin/draft/add）</summary>
public sealed class AddDraftRequest
{
    [JsonPropertyName("articles")] public required List<DraftArticle> Articles { get; set; }
}


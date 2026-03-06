using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取草稿响应</summary>
public class GetDraftResponse : WechatBaseResponse
{
    [JsonPropertyName("news_item")] public List<DraftArticle>? NewsItem { get; set; }
}


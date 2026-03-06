using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取图文群发每日数据响应（POST /datacube/getarticlesummary）</summary>
public class ArticleSummaryResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<ArticleSummaryItem>? List { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询发布状态响应</summary>
public class GetPublishResponse : WechatBaseResponse
{
    [JsonPropertyName("publish_id")] public string? PublishId { get; set; }
    /// <summary>发布状态（0 成功，1 发布中，2 原创失败，3 常规失败，4 平台审核不通过，5 成功后用户删除，6 成功后系统封禁）</summary>
    [JsonPropertyName("publish_status")] public int PublishStatus { get; set; }
    [JsonPropertyName("article_id")] public string? ArticleId { get; set; }
    [JsonPropertyName("article_detail")] public PublishArticleDetail? ArticleDetail { get; set; }
}


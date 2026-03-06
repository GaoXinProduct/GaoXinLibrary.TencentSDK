using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取用户反馈列表响应（GET /wxaapi/feedback/list）
/// </summary>
public class GetFeedbackListResponse : WechatBaseResponse
{
    /// <summary>反馈总数</summary>
    [JsonPropertyName("total")]    public int Total { get; set; }
    /// <summary>反馈列表</summary>
    [JsonPropertyName("list")]     public List<FeedbackItem>? List { get; set; }
}

/// <summary>用户反馈单条</summary>
public class FeedbackItem
{
    /// <summary>反馈ID</summary>
    [JsonPropertyName("feedback_id")]   public long FeedbackId { get; set; }
    /// <summary>用户openid</summary>
    [JsonPropertyName("openid")]        public string? OpenId { get; set; }
    /// <summary>反馈类型</summary>
    [JsonPropertyName("type")]          public int Type { get; set; }
    /// <summary>反馈内容</summary>
    [JsonPropertyName("content")]       public string? Content { get; set; }
    /// <summary>提交时间戳</summary>
    [JsonPropertyName("timestamp")]     public long Timestamp { get; set; }
    /// <summary>附带图片的 mediaId 列表</summary>
    [JsonPropertyName("media_ids")]     public List<string>? MediaIds { get; set; }
}

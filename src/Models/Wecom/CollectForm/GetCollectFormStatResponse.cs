using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表统计信息响应</summary>
public class GetCollectFormStatResponse : WecomBaseResponse
{
    /// <summary>收集表 ID</summary>
    [JsonPropertyName("formid")] public string? FormId { get; set; }

    /// <summary>收集表标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>收集表状态：1-进行中，2-已结束</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>已提交数量</summary>
    [JsonPropertyName("answered_count")] public int AnsweredCount { get; set; }

    /// <summary>已查看数量</summary>
    [JsonPropertyName("viewed_count")] public int ViewedCount { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

/// <summary>获取异步任务结果响应</summary>
public class GetAsyncJobResultResponse : WecomBaseResponse
{
    /// <summary>任务状态：1-处理中，2-已完成，3-异常失败</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>操作类型：sync_user(增量更新成员)，replace_user(全量覆盖成员)，replace_party(全量覆盖部门)</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>任务运行总条数</summary>
    [JsonPropertyName("total")] public int Total { get; set; }

    /// <summary>目前运行百分比，当任务完成时为空</summary>
    [JsonPropertyName("percentage")] public int? Percentage { get; set; }

    /// <summary>详细的处理结果</summary>
    [JsonPropertyName("result")] public AsyncImportResultItem[]? Result { get; set; }
}

using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

public enum SmartDocumentExportContentType : uint
{
    Markdown = 1
}

public sealed class CreateSmartDocumentExportTaskRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }

    [JsonPropertyName("content_type")]
    public SmartDocumentExportContentType ContentType { get; init; } = SmartDocumentExportContentType.Markdown;

    [JsonPropertyName("url")] public string? Url { get; init; }

    /// <summary>指定页面；省略时导出整个文档。</summary>
    [JsonPropertyName("page_id")] public string? PageId { get; init; }
}

public sealed class CreateSmartDocumentExportTaskResponse : WecomBaseResponse
{
    [JsonPropertyName("task_id")] public string? TaskId { get; init; }
}

public sealed class GetSmartDocumentExportResultRequest
{
    [JsonPropertyName("task_id")] public required string TaskId { get; init; }
}

public sealed class GetSmartDocumentExportResultResponse : WecomBaseResponse
{
    [JsonPropertyName("task_done")] public bool TaskDone { get; init; }

    /// <summary>任务完成时返回的 Markdown 内容。</summary>
    [JsonPropertyName("content")] public string? Content { get; init; }
}

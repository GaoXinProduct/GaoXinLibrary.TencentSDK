using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

public sealed class GetSmartDocumentDataSourceResponse : WecomBaseResponse
{
    /// <summary>与智能文档绑定的数据表文档 ID。</summary>
    [JsonPropertyName("ss_docid")] public string? SmartSheetDocId { get; init; }
}

public class SmartDocumentDataTableOptions
{
    [JsonPropertyName("title")] public string? Title { get; init; }

    /// <summary>目标位置前一个数据表的内容块 ID。</summary>
    [JsonPropertyName("after_id")] public string? AfterId { get; init; }
}

public class SmartDocumentDataTableLink : SmartDocumentDataTableOptions
{
    [JsonPropertyName("block_id")] public required string BlockId { get; init; }
}

public sealed class SmartDocumentDataTableInfo : SmartDocumentDataTableLink
{
    [JsonPropertyName("sheet_id")] public string? SheetId { get; init; }
    [JsonPropertyName("ss_docid")] public string? SmartSheetDocId { get; init; }
}

public sealed class AddSmartDocumentDataTableRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("info")] public required SmartDocumentDataTableOptions Info { get; init; }
}

public sealed class UpdateSmartDocumentDataTableRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("info")] public required SmartDocumentDataTableLink Info { get; init; }
}

public sealed class DeleteSmartDocumentDataTableRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("block_id")] public required string BlockId { get; init; }
}

public sealed class SmartDocumentDataTableResponse : WecomBaseResponse
{
    [JsonPropertyName("info")] public SmartDocumentDataTableInfo? Info { get; init; }
}

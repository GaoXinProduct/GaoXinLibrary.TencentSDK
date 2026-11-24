using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

public enum SmartDocumentPageLayoutMode : uint
{
    Default = 1,
    Paper = 2,
    FullWidth = 3
}

/// <summary>页面的名称、层级、排序位置及布局。</summary>
public class SmartDocumentPageOptions
{
    [JsonPropertyName("title")] public string? Title { get; init; }

    /// <summary>父页面 ID。空字符串表示根级页面。</summary>
    [JsonPropertyName("parent_id")] public string? ParentId { get; init; }

    /// <summary>目标位置的前一个页面 ID。</summary>
    [JsonPropertyName("after_id")] public string? AfterId { get; init; }

    [JsonPropertyName("layout_mode")] public SmartDocumentPageLayoutMode? LayoutMode { get; init; }
}

public sealed class SmartDocumentPageInfo : SmartDocumentPageOptions
{
    [JsonPropertyName("page_id")] public required string PageId { get; init; }
}

public sealed class AddSmartDocumentPageRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("info")] public required SmartDocumentPageOptions Info { get; init; }
}

public sealed class UpdateSmartDocumentPageRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("info")] public required SmartDocumentPageInfo Info { get; init; }
}

public sealed class DeleteSmartDocumentPageRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("page_id")] public required string PageId { get; init; }
}

public sealed class GetSmartDocumentPageHierarchyResponse : WecomBaseResponse
{
    [JsonPropertyName("pages")] public SmartDocumentPageInfo[]? Pages { get; init; }
}

public sealed class SmartDocumentPageResponse : WecomBaseResponse
{
    [JsonPropertyName("info")] public SmartDocumentPageInfo? Info { get; init; }
}

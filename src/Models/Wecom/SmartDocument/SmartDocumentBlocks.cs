using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

public class SmartDocumentBlockOptions
{
    /// <summary>内容块文本。新增接口使用此字段。</summary>
    [JsonPropertyName("title")] public string? Title { get; init; }

    [JsonPropertyName("parent_id")] public string? ParentId { get; init; }
    [JsonPropertyName("after_id")] public string? AfterId { get; init; }
    [JsonPropertyName("children")] public string[]? Children { get; init; }
    [JsonPropertyName("props")] public SmartDocumentBlockProps? Props { get; init; }
}

public sealed class NewSmartDocumentBlock : SmartDocumentBlockOptions
{
    /// <summary>官方内容块类型，如 BLOCK_TYPE_TEXT 或 BLOCK_TYPE_TODO。</summary>
    [JsonPropertyName("type")] public required string Type { get; init; }
}

public sealed class SmartDocumentBlockInfo : SmartDocumentBlockOptions
{
    [JsonPropertyName("id")] public required string Id { get; init; }
    [JsonPropertyName("type")] public string? Type { get; init; }

    /// <summary>获取列表和更新接口示例中的内容块文本字段。</summary>
    [JsonPropertyName("content")] public string? Content { get; init; }
}

public sealed class AddSmartDocumentBlocksRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("page_id")] public required string PageId { get; init; }
    [JsonPropertyName("blocks")] public required NewSmartDocumentBlock[] Blocks { get; init; }
}

public sealed class UpdateSmartDocumentBlocksRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("page_id")] public required string PageId { get; init; }
    [JsonPropertyName("blocks")] public required SmartDocumentBlockInfo[] Blocks { get; init; }
}

public sealed class DeleteSmartDocumentBlocksRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("page_id")] public required string PageId { get; init; }
    [JsonPropertyName("ids")] public required string[] Ids { get; init; }
}

public sealed class GetSmartDocumentBlocksRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }
    [JsonPropertyName("page_id")] public required string PageId { get; init; }
    [JsonPropertyName("ids")] public string[]? Ids { get; init; }

    /// <summary>分页起点，最小为 0。</summary>
    [JsonPropertyName("start")] public int? Start { get; init; }

    /// <summary>单页大小，默认及最大均为 200。</summary>
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class SmartDocumentBlocksResponse : WecomBaseResponse
{
    [JsonPropertyName("blocks")] public SmartDocumentBlockInfo[]? Blocks { get; init; }
}

public sealed class GetSmartDocumentBlocksResponse : SmartDocumentBlocksResponse
{
    [JsonPropertyName("has_more")]
    [JsonConverter(typeof(SmartDocumentHasMoreConverter))]
    public bool HasMore { get; init; }

    [JsonPropertyName("next_start")] public int? NextStart { get; init; }
}

internal sealed class SmartDocumentHasMoreConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.True or JsonTokenType.False)
            return reader.GetBoolean();

        if (reader.TokenType == JsonTokenType.String && bool.TryParse(reader.GetString(), out var value))
            return value;

        throw new JsonException("Invalid has_more value.");
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        => writer.WriteStringValue(value ? "true" : "false");
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

/// <summary>与内容块类型对应的属性。</summary>
public sealed class SmartDocumentBlockProps
{
    [JsonPropertyName("text_props")] public SmartDocumentTextProps? TextProps { get; init; }
    [JsonPropertyName("image_props")] public SmartDocumentImageProps? ImageProps { get; init; }
    [JsonPropertyName("file_props")] public SmartDocumentFileProps? FileProps { get; init; }
    [JsonPropertyName("link_props")] public SmartDocumentLinkProps? LinkProps { get; init; }
    [JsonPropertyName("table_props")] public SmartDocumentTableProps? TableProps { get; init; }
    [JsonPropertyName("view_props")] public SmartDocumentViewProps? ViewProps { get; init; }
    [JsonPropertyName("column_props")] public SmartDocumentColumnProps? ColumnProps { get; init; }
    [JsonPropertyName("highlight_props")] public SmartDocumentHighlightProps? HighlightProps { get; init; }
    [JsonPropertyName("code_props")] public SmartDocumentCodeProps? CodeProps { get; init; }
    [JsonPropertyName("todo_props")] public SmartDocumentTodoProps? TodoProps { get; init; }
}

public sealed class SmartDocumentTextProps
{
    [JsonPropertyName("align")] public uint? Align { get; init; }
    [JsonPropertyName("text_align")] public uint? TextAlign { get; init; }
    [JsonPropertyName("block_color")] public string? BlockColor { get; init; }
}

public sealed class SmartDocumentImageProps
{
    [JsonPropertyName("url")] public string? Url { get; init; }
    [JsonPropertyName("width")] public double? Width { get; init; }
    [JsonPropertyName("height")] public double? Height { get; init; }
    [JsonPropertyName("stroke")] public bool? Stroke { get; init; }
}

public sealed class SmartDocumentFileProps
{
    [JsonPropertyName("file_id")] public string? FileId { get; init; }
}

public sealed class SmartDocumentLinkProps
{
    [JsonPropertyName("link_url")] public string? LinkUrl { get; init; }
    [JsonPropertyName("link_name")] public string? LinkName { get; init; }
    [JsonPropertyName("link_description")] public string? LinkDescription { get; init; }
}

public sealed class SmartDocumentTableProps
{
    [JsonPropertyName("cell_positions")] public SmartDocumentTableCellMerge[]? CellPositions { get; init; }
    [JsonPropertyName("enable_row_header")] public bool? EnableRowHeader { get; init; }
    [JsonPropertyName("enable_column_header")] public bool? EnableColumnHeader { get; init; }
}

public sealed class SmartDocumentTableCellMerge
{
    [JsonPropertyName("start_cell")] public required SmartDocumentTableCellPosition StartCell { get; init; }
    [JsonPropertyName("end_cell")] public required SmartDocumentTableCellPosition EndCell { get; init; }
}

public sealed class SmartDocumentTableCellPosition
{
    [JsonPropertyName("row")] public uint Row { get; init; }
    [JsonPropertyName("column")] public uint Column { get; init; }
}

public sealed class SmartDocumentViewProps
{
    [JsonPropertyName("doc_id")] public string? DocId { get; init; }
    [JsonPropertyName("table_id")] public string? TableId { get; init; }
    [JsonPropertyName("view_id")] public string? ViewId { get; init; }
    [JsonPropertyName("table_block_id")] public string? TableBlockId { get; init; }
    [JsonPropertyName("enable_table_title")] public bool? EnableTableTitle { get; init; }
    [JsonPropertyName("enable_add_row")] public bool? EnableAddRow { get; init; }
}

public sealed class SmartDocumentColumnProps
{
    [JsonPropertyName("column_num")] public uint? ColumnCount { get; init; }
}

public sealed class SmartDocumentHighlightProps
{
    [JsonPropertyName("background_image_url")] public string? BackgroundImageUrl { get; init; }
    [JsonPropertyName("extend_background")] public bool? ExtendBackground { get; init; }
    [JsonPropertyName("block_color")] public string? BlockColor { get; init; }
    [JsonPropertyName("border_color")] public string? BorderColor { get; init; }
}

public sealed class SmartDocumentCodeProps
{
    /// <summary>代码语言。保留 API 返回的 JSON 表示。</summary>
    [JsonPropertyName("code_language")] public JsonElement? CodeLanguage { get; init; }
    [JsonPropertyName("code_wrap")] public bool? CodeWrap { get; init; }
}

public sealed class SmartDocumentTodoProps
{
    [JsonPropertyName("checked")] public bool? IsChecked { get; init; }
}

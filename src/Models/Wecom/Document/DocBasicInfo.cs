using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>文档基础信息</summary>
public class DocBasicInfo
{
    /// <summary>文档 docid</summary>
    [JsonPropertyName("docid")] public string? DocId { get; set; }

    /// <summary>文档标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>创建时间</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }

    /// <summary>最后修改时间</summary>
    [JsonPropertyName("update_time")] public long UpdateTime { get; set; }

    /// <summary>文档作者 userid</summary>
    [JsonPropertyName("author_userid")] public string? AuthorUserId { get; set; }

    /// <summary>文档类型：1-文档，3-表格，4-收集表，5-目录</summary>
    [JsonPropertyName("doc_type")] public int DocType { get; set; }

    /// <summary>父文件夹 ID</summary>
    [JsonPropertyName("parent_id")] public string? ParentId { get; set; }
}

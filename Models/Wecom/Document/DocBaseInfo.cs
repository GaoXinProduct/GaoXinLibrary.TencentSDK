using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>文档基础信息</summary>
public class DocBaseInfo
{
    /// <summary>文档docid</summary>
    [JsonPropertyName("docid")] public string? DocId { get; set; }

    /// <summary>文档名称</summary>
    [JsonPropertyName("doc_name")] public string? DocName { get; set; }

    /// <summary>文档创建时间</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }

    /// <summary>文档修改时间</summary>
    [JsonPropertyName("modify_time")] public long ModifyTime { get; set; }

    /// <summary>文档类型，1-文档，3-表格，4-收集表</summary>
    [JsonPropertyName("doc_type")] public int DocType { get; set; }

    /// <summary>文档创建者userid</summary>
    [JsonPropertyName("creator_userid")] public string? CreatorUserId { get; set; }
}

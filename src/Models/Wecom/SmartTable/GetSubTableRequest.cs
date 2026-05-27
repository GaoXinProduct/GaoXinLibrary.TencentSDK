using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询子表请求</summary>
public record GetSubTableRequest([property:JsonPropertyName("docid")] string DocId);

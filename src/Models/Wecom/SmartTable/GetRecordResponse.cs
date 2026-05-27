using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询记录响应</summary>
public class GetRecordResponse : WecomBaseResponse
{
    /// <summary>记录列表</summary>
    [JsonPropertyName("records")] public RecordInfo[]? Records { get; set; }

    /// <summary>是否还有更多</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>下次查询游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

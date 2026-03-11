using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

/// <summary>获取操作日志响应</summary>
public class GetOperationLogResponse : WecomBaseResponse
{
    /// <summary>是否还有更多</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }

    /// <summary>操作记录列表</summary>
    [JsonPropertyName("operation_records")] public OperationRecord[]? OperationRecords { get; set; }
}

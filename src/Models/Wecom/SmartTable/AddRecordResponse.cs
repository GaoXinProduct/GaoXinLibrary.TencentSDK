using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加记录响应</summary>
public class AddRecordResponse : WecomBaseResponse
{
    /// <summary>添加的记录列表</summary>
    [JsonPropertyName("records")] public RecordInfo[]? Records { get; set; }
}

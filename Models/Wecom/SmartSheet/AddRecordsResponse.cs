using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>添加记录响应</summary>
public class AddRecordsResponse : WecomBaseResponse
{
    /// <summary>添加的记录列表</summary>
    [JsonPropertyName("records")] public SheetRecord[]? Records { get; set; }
}

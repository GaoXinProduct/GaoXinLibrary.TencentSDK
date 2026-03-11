using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取记录列表响应</summary>
public class GetRecordsResponse : WecomBaseResponse
{
    /// <summary>记录列表</summary>
    [JsonPropertyName("records")] public SheetRecord[]? Records { get; set; }

    /// <summary>是否还有更多</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>记录总数</summary>
    [JsonPropertyName("total")] public int Total { get; set; }
}

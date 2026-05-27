using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加视图响应</summary>
public class AddViewResponse : WecomBaseResponse
{
    /// <summary>视图 ID</summary>
    [JsonPropertyName("view_id")] public string? ViewId { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询视图响应</summary>
public class GetViewResponse : WecomBaseResponse
{
    /// <summary>视图列表</summary>
    [JsonPropertyName("views")] public ViewInfo[]? Views { get; set; }
}

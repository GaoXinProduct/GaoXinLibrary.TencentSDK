using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取视图列表响应</summary>
public class GetViewsResponse : WecomBaseResponse
{
    /// <summary>视图列表</summary>
    [JsonPropertyName("views")] public SheetView[]? Views { get; set; }
}

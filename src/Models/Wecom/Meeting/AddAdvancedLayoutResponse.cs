using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>添加会议高级布局响应</summary>
/// <remarks>doc path: /98861</remarks>
public class AddAdvancedLayoutResponse : WecomBaseResponse
{
    /// <summary>布局ID</summary>
    [JsonPropertyName("layout_id")]
    public string? LayoutId { get; set; }
}
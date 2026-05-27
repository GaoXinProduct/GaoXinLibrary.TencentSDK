using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>添加会议背景响应</summary>
/// <remarks>doc path: /98851</remarks>
public class AddMeetingBackgroundResponse : WecomBaseResponse
{
    /// <summary>背景ID</summary>
    [JsonPropertyName("background_id")]
    public string? BackgroundId { get; set; }
}
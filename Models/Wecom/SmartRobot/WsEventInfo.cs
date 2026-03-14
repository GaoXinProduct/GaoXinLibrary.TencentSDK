using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 事件详情
/// <para>
/// 支持的事件类型：enter_chat / template_card_event / feedback_event / disconnected_event
/// </para>
/// </summary>
public class WsEventInfo
{
    /// <summary>事件类型（enter_chat / template_card_event / feedback_event / disconnected_event）</summary>
    [JsonPropertyName("eventtype")] public string EventType { get; set; } = string.Empty;

    /// <summary>额外的事件数据（根据事件类型不同而不同）</summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

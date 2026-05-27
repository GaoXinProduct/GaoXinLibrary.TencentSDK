using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取设备票据请求（POST /cgi-bin/device/ticket/get_ticket）
/// </summary>
public sealed class GetSnTicketRequest
{
    /// <summary>设备序列号</summary>
    [JsonPropertyName("sn")] public required string Sn { get; set; }
    /// <summary>设备类型</summary>
    [JsonPropertyName("device_type")] public required string DeviceType { get; set; }
}
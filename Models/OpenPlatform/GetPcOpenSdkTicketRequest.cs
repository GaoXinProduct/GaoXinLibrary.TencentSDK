using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取 PC OpenSDK ticket 请求（POST /cgi-bin/pcopensdk/ticket）
/// </summary>
public class GetPcOpenSdkTicketRequest
{
    /// <summary>授权的票据类型，固定为 "pcopensdk"</summary>
    [JsonPropertyName("ticket_type")] public string TicketType { get; set; } = "pcopensdk";
}


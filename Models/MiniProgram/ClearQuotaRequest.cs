using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 清除接口调用次数请求（POST /cgi-bin/clear_quota）
/// </summary>
public class ClearQuotaRequest
{
    /// <summary>小程序的 AppId</summary>
    [JsonPropertyName("appid")] public required string AppId { get; set; }
}


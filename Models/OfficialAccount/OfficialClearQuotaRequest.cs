using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>清空 api 调用次数请求（POST /cgi-bin/clear_quota）</summary>
public class OfficialClearQuotaRequest
{
    [JsonPropertyName("appid")] public required string AppId { get; set; }
}


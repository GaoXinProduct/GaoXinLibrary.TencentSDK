using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

// ─── 响应模型 ──────────────────────────────────────────────────────────────

public class SendMessageResponse : WecomBaseResponse
{
    [JsonPropertyName("invaliduser")] public string? InvalidUser { get; set; }
    [JsonPropertyName("invalidparty")] public string? InvalidParty { get; set; }
    [JsonPropertyName("invalidtag")] public string? InvalidTag { get; set; }
    [JsonPropertyName("unlicenseduser")] public string? UnlicensedUser { get; set; }
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }
    [JsonPropertyName("response_code")] public string? ResponseCode { get; set; }
}


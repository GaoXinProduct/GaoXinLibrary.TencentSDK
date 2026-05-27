using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取联系我方式响应</summary>
public sealed class GetContactWayResponse : WecomBaseResponse
{
    [JsonPropertyName("contact_way")] public ContactWayInfo? ContactWay { get; set; }
}

public sealed class ContactWayInfo
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("scene")] public int Scene { get; set; }
    [JsonPropertyName("style")] public int Style { get; set; }
    [JsonPropertyName("remark")] public string? Remark { get; set; }
    [JsonPropertyName("skip_verify")] public bool SkipVerify { get; set; }
    [JsonPropertyName("state")] public string? State { get; set; }
    [JsonPropertyName("qr_code")] public string? QrCode { get; set; }
    [JsonPropertyName("user")] public string[]? User { get; set; }
    [JsonPropertyName("party")] public int[]? Party { get; set; }
    [JsonPropertyName("is_temp")] public bool IsTemp { get; set; }
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    [JsonPropertyName("chat_expires_in")] public int ChatExpiresIn { get; set; }
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
    [JsonPropertyName("conclusions")] public ContactWayConclusions? Conclusions { get; set; }
}

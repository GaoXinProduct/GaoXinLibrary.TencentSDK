namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>更新联系我方式请求</summary>
public sealed class UpdateContactWayRequest
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
    [JsonPropertyName("remark")] public string? Remark { get; set; }
    [JsonPropertyName("skip_verify")] public bool? SkipVerify { get; set; }
    [JsonPropertyName("state")] public string? State { get; set; }
    [JsonPropertyName("user")] public string[]? User { get; set; }
    [JsonPropertyName("party")] public int[]? Party { get; set; }
    [JsonPropertyName("expires_in")] public int? ExpiresIn { get; set; }
    [JsonPropertyName("chat_expires_in")] public int? ChatExpiresIn { get; set; }
    [JsonPropertyName("conclusions")] public ContactWayConclusions? Conclusions { get; set; }
}

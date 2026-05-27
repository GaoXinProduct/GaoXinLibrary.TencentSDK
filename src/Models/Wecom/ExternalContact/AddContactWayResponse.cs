using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>配置联系我方式响应</summary>
public sealed class AddContactWayResponse : WecomBaseResponse
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
    [JsonPropertyName("qr_code")] public string? QrCode { get; set; }
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取入群欢迎语素材请求</summary>
public sealed class GetWelcomeTemplateRequest
{
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;
}

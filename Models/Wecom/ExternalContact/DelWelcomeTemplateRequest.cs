namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>删除入群欢迎语素材请求</summary>
public sealed class DelWelcomeTemplateRequest
{
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
}

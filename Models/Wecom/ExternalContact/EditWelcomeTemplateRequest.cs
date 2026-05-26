namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>编辑入群欢迎语素材请求</summary>
public sealed class EditWelcomeTemplateRequest
{
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;
    [JsonPropertyName("text")] public WelcomeMsgText? Text { get; set; }
    [JsonPropertyName("image")] public WelcomeMsgImage? Image { get; set; }
    [JsonPropertyName("link")] public WelcomeMsgLink? Link { get; set; }
    [JsonPropertyName("miniprogram")] public WelcomeMsgMiniProgram? MiniProgram { get; set; }
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
}

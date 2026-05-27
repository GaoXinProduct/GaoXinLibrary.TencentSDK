using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>添加欢迎语响应</summary>
public sealed class AddWelcomeTemplateResponse : WecomBaseResponse
{
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;
}

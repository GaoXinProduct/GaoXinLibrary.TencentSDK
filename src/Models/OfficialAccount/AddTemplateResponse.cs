using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取模板 ID 响应</summary>
public sealed class AddTemplateResponse : WechatBaseResponse
{
    [JsonPropertyName("template_id")] public string? TemplateId { get; set; }
}


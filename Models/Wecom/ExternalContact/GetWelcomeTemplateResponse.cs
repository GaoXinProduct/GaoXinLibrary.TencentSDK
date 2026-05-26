using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取欢迎语响应</summary>
public sealed class GetWelcomeTemplateResponse : WecomBaseResponse
{
    [JsonPropertyName("text")] public WelcomeMsgText? Text { get; set; }
    [JsonPropertyName("image")] public WelcomeMsgImage? Image { get; set; }
    [JsonPropertyName("link")] public WelcomeMsgLink? Link { get; set; }
    [JsonPropertyName("miniprogram")] public WelcomeMsgMiniProgram? MiniProgram { get; set; }
}

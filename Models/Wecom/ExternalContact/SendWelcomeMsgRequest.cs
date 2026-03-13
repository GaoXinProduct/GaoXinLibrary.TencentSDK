using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>发送新客户欢迎语请求</summary>
public class SendWelcomeMsgRequest
{
    /// <summary>欢迎语 code</summary>
    [JsonPropertyName("welcome_code")]
    public string WelcomeCode { get; set; } = string.Empty;

    /// <summary>文本消息</summary>
    [JsonPropertyName("text")]
    public object Text { get; set; } = new();

    /// <summary>图片消息</summary>
    [JsonPropertyName("image")]
    public object? Image { get; set; }

    /// <summary>链接消息</summary>
    [JsonPropertyName("link")]
    public object? Link { get; set; }

    /// <summary>小程序消息</summary>
    [JsonPropertyName("miniprogram")]
    public object? MiniProgram { get; set; }
}

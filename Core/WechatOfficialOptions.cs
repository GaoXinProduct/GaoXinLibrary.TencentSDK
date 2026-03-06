namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信公众号配置
/// </summary>
public class WechatOfficialOptions : WechatOptions
{
    /// <summary>接收消息回调的 Token（用于签名校验）</summary>
    public string? CallbackToken { get; set; }

    /// <summary>接收消息回调的 EncodingAESKey（用于消息加解密，43 位字符）</summary>
    public string? CallbackEncodingAesKey { get; set; }
}

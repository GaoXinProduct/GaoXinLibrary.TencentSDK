namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// QQ 互联配置（QQ 登录）
/// </summary>
public class QQConnectOptions : WechatOptions
{
    /// <summary>API 基础地址，默认 https://graph.qq.com</summary>
    public new string BaseUrl { get; set; } = "https://graph.qq.com";
}

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信群机器人配置
/// <para>
/// 通过 <c>AddWecomWebHookService</c> 注册时使用此类型。
/// 仅包含群机器人 Webhook Key，与 <see cref="WecomOptions"/> 完全解耦。
/// </para>
/// </summary>
public class WecomWebHookOptions
{
    /// <summary>
    /// 群机器人 Webhook Key
    /// <para>在企业微信群机器人配置页获取，注册后无需每次调用时传入。</para>
    /// </summary>
    public string? WebhookKey { get; set; }
}

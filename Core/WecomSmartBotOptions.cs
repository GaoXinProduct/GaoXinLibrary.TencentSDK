namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信智能机器人配置
/// <para>
/// 通过 <c>AddWecomSmartBotService</c> 注册时使用此类型。
/// 与群机器人配置（<see cref="WecomWebHookOptions"/>）完全解耦，不继承 <see cref="WecomOptions"/>。
/// </para>
/// </summary>
public class WecomSmartBotOptions
{
    // ─── 企业微信核心配置（主动发消息所需）─────────────────────────────

    /// <summary>企业ID（corpid）</summary>
    public string CorpId { get; set; } = string.Empty;

    /// <summary>应用的凭证密钥（corpsecret）</summary>
    public string CorpSecret { get; set; } = string.Empty;

    /// <summary>自建应用 AgentId（消息发送时使用）</summary>
    public int AgentId { get; set; }

    /// <summary>API 基础地址，默认 https://qyapi.weixin.qq.com</summary>
    public string BaseUrl { get; set; } = "https://qyapi.weixin.qq.com";

    /// <summary>HTTP 请求超时时间，默认 30 秒</summary>
    public TimeSpan HttpTimeout { get; set; } = TimeSpan.FromSeconds(30);

    // ─── 智能机器人回调配置（API 模式）──────────────────────────────────

    /// <summary>接收消息回调的 Token（用于签名校验）</summary>
    public string? CallbackToken { get; set; }

    /// <summary>接收消息回调的 EncodingAESKey（用于消息加解密，43 位字符）</summary>
    public string? CallbackEncodingAesKey { get; set; }

    // ─── 智能机器人长连接配置 ─────────────────────────────────────────

    /// <summary>
    /// 智能机器人 BotID（长连接模式专用）
    /// <para>在企业微信管理后台智能机器人配置页获取。仅当同时配置 <see cref="BotId"/> 和 <see cref="BotSecret"/> 时，<c>ISmartRobotWsClient</c> 才会被注册。</para>
    /// </summary>
    public string? BotId { get; set; }

    /// <summary>
    /// 智能机器人长连接专用密钥 Secret
    /// <para>与回调模式的 Token/EncodingAESKey 不同，请妥善保管。</para>
    /// </summary>
    public string? BotSecret { get; set; }

    /// <summary>智能机器人长连接 WebSocket 地址，默认 wss://openws.work.weixin.qq.com</summary>
    public string BotWsUrl { get; set; } = "wss://openws.work.weixin.qq.com";
}

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

    // ─── JS-SDK Ticket 共享配置 ─────────────────────────────────────────────

    /// <summary>
    /// 共享 jsapi_ticket 密钥（采用 ChaCha20-Poly1305 加密）
    /// <para>
    /// 设置后可通过 <c>GetSharedTicketAsync()</c> 获取加密形式的 Ticket 供其他服务消费，
    /// 或配合 <see cref="TicketShareUrl"/> 从远端获取并自动解密。
    /// 密钥可为任意字符串，内部使用 SHA-256 派生为 32 字节密钥。
    /// </para>
    /// </summary>
    public string? TicketShareSecret { get; set; }

    /// <summary>
    /// 共享 jsapi_ticket 远端地址
    /// <para>
    /// 设置后将从此地址（HTTP GET）获取加密 Ticket，而非直接向微信 API 请求。
    /// 远端响应格式：<c>{"token":"BASE64加密数据","expires_in":7200}</c>，需与 <see cref="TicketShareSecret"/> 配合使用。
    /// </para>
    /// </summary>
    public string? TicketShareUrl { get; set; }

    /// <summary>
    /// Ticket 变更通知回调
    /// <para>每次成功刷新 jsapi_ticket 后触发，参数为新的明文 ticket 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTicketChanged { get; set; }
}

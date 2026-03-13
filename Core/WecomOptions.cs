using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信客户端配置
/// </summary>
public class WecomOptions
{
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

    // ─── 接收消息回调配置 ───────────────────────────────────────────────

    /// <summary>接收消息回调的 Token（用于签名校验）</summary>
    public string? CallbackToken { get; set; }

    /// <summary>接收消息回调的 EncodingAESKey（用于消息加解密，43 位字符）</summary>
    public string? CallbackEncodingAesKey { get; set; }

    // ─── 会话内容存档配置 ───────────────────────────────────────────────

    /// <summary>
    /// 会话内容存档密钥（非应用 CorpSecret）
    /// <para>在企业微信管理后台「管理工具 - 会话内容存档」中获取。</para>
    /// </summary>
    public string? MsgAuditSecret { get; set; }

    /// <summary>
    /// 会话内容存档 RSA 私钥（PEM 格式）
    /// <para>用于解密 GetChatData 返回的 encrypt_random_key。</para>
    /// </summary>
    public string? MsgAuditPrivateKey { get; set; }

    // ─── 共享 Token 配置 ─────────────────────────────────────────────────────

    /// <summary>
    /// 共享 Token 密钥（采用 ChaCha20-Poly1305 加密）
    /// <para>
    /// 设置后可通过 <c>GetSharedAccessTokenAsync()</c> 获取加密形式的 Token 供其他服务消费，
    /// 或配合 <see cref="TokenShareUrl"/> 从远端获取并自动解密。
    /// 密钥可为任意字符串，内部使用 SHA-256 派生为 32 字节密钥。
    /// </para>
    /// </summary>
    public string? ShareSecret { get; set; }

    /// <summary>
    /// 共享 Token 远端地址
    /// <para>
    /// 设置后将从此地址（HTTP GET）获取加密 Token，而非直接向企业微信 API 请求。
    /// 远端响应格式：<c>{"token":"BASE64加密数据","expires_in":7200}</c>，需与 <see cref="ShareSecret"/> 配合使用。
    /// </para>
    /// </summary>
    public string? TokenShareUrl { get; set; }

    /// <summary>
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，参数为新的明文 access_token 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    // ─── 共享 JS-SDK Ticket 配置（企业级 jsapi_ticket） ──────────────────────

    /// <summary>
    /// 企业级 jsapi_ticket 共享密钥（ChaCha20-Poly1305 加密）
    /// <para>
    /// 设置后可通过 <c>GetSharedJsApiTicketAsync()</c> 获取加密形式的 Ticket 供其他服务消费，
    /// 或配合 <see cref="JsApiTicketShareUrl"/> 从远端获取并自动解密。
    /// </para>
    /// </summary>
    public string? JsApiTicketShareSecret { get; set; }

    /// <summary>
    /// 企业级 jsapi_ticket 共享远端地址
    /// <para>
    /// 设置后将从此地址（HTTP GET）获取加密 Ticket，而非直接向企业微信 API 请求。
    /// 远端响应格式：<c>{"token":"BASE64加密数据","expires_in":7200}</c>，需与 <see cref="JsApiTicketShareSecret"/> 配合使用。
    /// </para>
    /// </summary>
    public string? JsApiTicketShareUrl { get; set; }

    /// <summary>
    /// 企业级 jsapi_ticket 变更通知回调
    /// <para>每次成功刷新 jsapi_ticket 后触发，参数为新的明文 jsapi_ticket 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnJsApiTicketChanged { get; set; }

    // ─── 共享 JS-SDK Ticket 配置（应用级 agent_ticket） ──────────────────────

    /// <summary>
    /// 应用级 jsapi_ticket 共享密钥（ChaCha20-Poly1305 加密）
    /// <para>
    /// 设置后可通过 <c>GetSharedAgentTicketAsync()</c> 获取加密形式的 Ticket 供其他服务消费，
    /// 或配合 <see cref="AgentTicketShareUrl"/> 从远端获取并自动解密。
    /// </para>
    /// </summary>
    public string? AgentTicketShareSecret { get; set; }

    /// <summary>
    /// 应用级 jsapi_ticket 共享远端地址
    /// <para>
    /// 设置后将从此地址（HTTP GET）获取加密 Ticket，而非直接向企业微信 API 请求。
    /// 远端响应格式：<c>{"token":"BASE64加密数据","expires_in":7200}</c>，需与 <see cref="AgentTicketShareSecret"/> 配合使用。
    /// </para>
    /// </summary>
    public string? AgentTicketShareUrl { get; set; }

    /// <summary>
    /// 应用级 jsapi_ticket 变更通知回调
    /// <para>每次成功刷新应用 jsapi_ticket 后触发，参数为新的明文 jsapi_ticket 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnAgentTicketChanged { get; set; }

    // ─── 瞬态故障重试配置 ─────────────────────────────────────────────────────

    /// <summary>
    /// 瞬态故障重试配置（网络抖动、连接超时、5xx 等临时性故障）
    /// <para>
    /// 默认最多重试 2 次、指数退避 500ms 起步。设为 <c>null</c> 或 <c>MaxRetries = 0</c> 禁用重试。<br/>
    /// Token 失效重试由 SDK 内部独立处理，不受此配置影响。
    /// </para>
    /// </summary>
    public TencentRetryOptions? RetryOptions { get; set; } = new();
}

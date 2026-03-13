using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信客户端配置基类
/// </summary>
public class WechatOptions
{
    /// <summary>应用 ID（AppID）</summary>
    public string AppId { get; set; } = string.Empty;

    /// <summary>应用密钥（AppSecret）</summary>
    public string AppSecret { get; set; } = string.Empty;

    /// <summary>API 基础地址，默认 https://api.weixin.qq.com</summary>
    public string BaseUrl { get; set; } = "https://api.weixin.qq.com";

    /// <summary>HTTP 请求超时时间，默认 30 秒</summary>
    public TimeSpan HttpTimeout { get; set; } = TimeSpan.FromSeconds(30);

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
    /// 设置后将从此地址（HTTP GET）获取加密 Token，而非直接向微信 API 请求。
    /// 远端响应格式：<c>{"token":"BASE64加密数据","expires_in":7200}</c>，需与 <see cref="ShareSecret"/> 配合使用。
    /// </para>
    /// </summary>
    public string? TokenShareUrl { get; set; }

    /// <summary>
    /// 统一共享密钥远端地址
    /// <para>
    /// 设置后将从此地址（HTTP GET）获取加密的 <see cref="SharedSecretPayload"/>，而非直接向微信 API 请求。<br/>
    /// 远端响应格式：<c>{"data":"BASE64加密数据"}</c>，密文解密后为包含 access_token、jsapi_ticket、AppId、AppSecret 等全部敏感信息的 JSON。<br/>
    /// 需与 <see cref="ShareSecret"/> 配合使用。设置此项后无需配置 <see cref="WechatOptions.AppId"/>、
    /// <see cref="WechatOptions.AppSecret"/>、<see cref="TokenShareUrl"/>。
    /// </para>
    /// </summary>
    public string? SecretShareUrl { get; set; }

    /// <summary>
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，参数为新的明文 access_token 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

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

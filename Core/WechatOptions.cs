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
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，参数为新的明文 access_token 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }
}

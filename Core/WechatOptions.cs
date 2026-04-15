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

    /// <summary>
    /// 共享密钥
    /// <para>
    /// 备服务器模式下必填，与主服务器约定的同一密钥（ChaCha20-Poly1305，内部通过 SHA-256 派生为 32 字节密钥）。<br/>
    /// 主服务器侧亦可配置，供 <see cref="TencentTokenCrypto"/> 工具类直接使用。
    /// </para>
    /// </summary>
    public string? ShareSecret { get; set; }

    /// <summary>
    /// 统一共享密钥远端地址
    /// <para>
    /// 配置后，SDK 将从该 URL 拉取加密的 <see cref="SharedSecretPayload"/> 载荷（JSON 格式，字段 <c>data</c> 为加密字符串）。<br/>
    /// 载荷解密后包含 access_token、jsapi_ticket、AppId、AppSecret 等全部敏感信息，备服务器无需配置 AppSecret 即可正常运行。<br/>
    /// 注意：配置 <see cref="SecretShareUrl"/> 时必须同时配置 <see cref="ShareSecret"/>。
    /// </para>
    /// </summary>
    public string? SecretShareUrl { get; set; }

    /// <summary>
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，参数为新的明文 access_token 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    #region 瞬态故障重试配置

    /// <summary>
    /// 瞬态故障重试配置（网络抖动、连接超时、5xx 等临时性故障）
    /// <para>
    /// 默认最多重试 2 次、指数退避 500ms 起步。设为 <c>null</c> 或 <c>MaxRetries = 0</c> 禁用重试。<br/>
    /// Token 失效重试由 SDK 内部独立处理，不受此配置影响。
    /// </para>
    /// </summary>
    public TencentRetryOptions? RetryOptions { get; set; } = new();
    #endregion
}

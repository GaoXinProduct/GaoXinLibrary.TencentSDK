using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信 Access Token 获取与缓存管理
/// </summary>
public class AccessTokenProvider : TencentAccessTokenProvider
{
    private readonly WechatOptions _options;

    public AccessTokenProvider(WechatOptions options, HttpClient httpClient)
        : base(httpClient, "微信")
    {
        _options = options;
        ConfigureSharedToken(options.ShareSecret, options.TokenShareUrl, options.SecretShareUrl);
        OnTokenChanged = options.OnTokenChanged;
    }

    /// <inheritdoc/>
    protected override string BuildTokenUrl()
        => $"{_options.BaseUrl.TrimEnd('/')}/cgi-bin/token?grant_type=client_credential&appid={Uri.EscapeDataString(_options.AppId)}&secret={Uri.EscapeDataString(_options.AppSecret)}";
}

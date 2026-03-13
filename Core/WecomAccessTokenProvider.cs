using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信 Access Token 获取与缓存管理
/// </summary>
public class AccessTokenProvider : TencentAccessTokenProvider
{
    private readonly WecomOptions _options;

    public AccessTokenProvider(WecomOptions options, HttpClient httpClient)
        : base(httpClient, "企业微信")
    {
        _options = options;
        ConfigureSharedToken(options.ShareSecret, options.TokenShareUrl, options.SecretShareUrl);
        OnTokenChanged = options.OnTokenChanged;
    }

    /// <inheritdoc/>
    protected override string BuildTokenUrl()
        => $"{_options.BaseUrl}/cgi-bin/gettoken?corpid={_options.CorpId}&corpsecret={_options.CorpSecret}";
}

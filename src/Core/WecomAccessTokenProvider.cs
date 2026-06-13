
namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信 Access Token 获取与缓存管理
/// </summary>
public sealed class AccessTokenProvider : TencentAccessTokenProvider
{
    private readonly WecomOptions _options;

    public AccessTokenProvider(WecomOptions options, HttpClient httpClient)
        : base(httpClient, "企业微信")
    {
        _options = options;
        OnTokenChanged = options.OnTokenChanged;

    }

    /// <inheritdoc/>
    protected override string BuildTokenUrl()
        => $"{_options.BaseUrl}/cgi-bin/gettoken?corpid={_options.CorpId}&corpsecret={_options.CorpSecret}";
}


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
        => $"{_options.BaseUrl.TrimEnd('/')}/cgi-bin/gettoken?corpid={Uri.EscapeDataString(_options.CorpId)}&corpsecret={Uri.EscapeDataString(_options.CorpSecret)}";

    // 企业微信 40001 表示应用 Secret 无效。
    internal override bool IsRejectedTokenError(int errCode) => errCode is 40014 or 42001;
}

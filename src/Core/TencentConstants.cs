namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>腾讯 SDK 内部常量</summary>
public static class TencentConstants
{
    #region 企业微信

    /// <summary>
    /// 企业微信 HttpClient 名称。
    /// <para>在 DI 场景下注册后，可使用 <c>IHttpClientFactory.CreateClient(TencentConstants.WecomHttpClientName)</c> 手动获取该客户端。</para>
    /// </summary>
    public const string WecomHttpClientName = "GaoXinLibrary.TencentSDK.Wecom";

    #endregion
    #region 微信小程序

    /// <summary>小程序 HttpClient 名称</summary>
    public const string MiniProgramHttpClientName = "GaoXinLibrary.TencentSDK.Wechat.MiniProgram";

    #endregion
    #region 微信公众号

    /// <summary>公众号 HttpClient 名称</summary>
    public const string OfficialHttpClientName = "GaoXinLibrary.TencentSDK.Wechat.Official";

    /// <summary>微信公众号 OAuth 基础地址</summary>
    public const string OfficialOAuthBaseUrl = "https://open.weixin.qq.com";

    #endregion
    #region 微信开放平台

    /// <summary>开放平台 HttpClient 名称</summary>
    public const string OpenHttpClientName = "GaoXinLibrary.TencentSDK.Wechat.Open";

    /// <summary>微信开放平台 OAuth 基础地址</summary>
    public const string OpenBaseUrl = "https://open.weixin.qq.com";

    #endregion
    #region QQ 互联

    /// <summary>QQ 互联 HttpClient 名称</summary>
    public const string QQConnectHttpClientName = "GaoXinLibrary.TencentSDK.Wechat.QQConnect";

    /// <summary>QQ 互联 OAuth 基础地址</summary>
    public const string QQConnectBaseUrl = "https://graph.qq.com";
    #endregion
}

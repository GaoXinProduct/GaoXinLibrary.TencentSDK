namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信小程序配置
/// </summary>
public sealed class WechatMiniProgramOptions : WechatOptions
{
    /// <summary>
    /// 主备服务器共享密钥（主服务器调用 <see cref="WechatMiniProgramClient.GetSharedSecretAsync(System.Threading.CancellationToken)"/> 时使用）
    /// <para>配置后可不传参直接调用 GetSharedSecretAsync()。</para>
    /// </summary>
    public string? ShareSecret { get; set; }
}

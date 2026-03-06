using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信公众号消息加解密工具
/// <para>
/// 继承 <see cref="TencentCryptoHelper"/>，提供微信平台特定的异常类型。<br/>
/// 适用于安全模式和兼容模式下的消息加解密。<br/>
/// 参考文档：<see href="https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Message_Encryption_and_Decryption_Instructions.html"/>
/// </para>
/// </summary>
public sealed class WechatCryptoHelper : TencentCryptoHelper
{
    /// <summary>
    /// 初始化微信消息加解密工具
    /// </summary>
    /// <param name="token">公众号后台配置的 Token</param>
    /// <param name="encodingAesKey">公众号后台配置的 EncodingAESKey（43 位字符）</param>
    /// <param name="appId">公众号 AppID</param>
    public WechatCryptoHelper(string token, string encodingAesKey, string appId)
        : base(token, encodingAesKey, appId) { }

    /// <summary>
    /// 验证明文模式下的签名（仅使用 token、timestamp、nonce 进行 SHA1 校验）
    /// </summary>
    /// <param name="signature">URL 参数 signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <returns>签名是否合法</returns>
    public bool VerifyPlainSignature(string signature, string timestamp, string nonce)
    {
        return VerifySignature(signature, timestamp, nonce);
    }
}

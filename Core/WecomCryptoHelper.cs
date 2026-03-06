using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信消息加解密工具
/// <para>
/// 继承 <see cref="TencentCryptoHelper"/>，提供企业微信平台特定的异常类型。<br/>
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90238"/>
/// </para>
/// </summary>
public sealed class WecomCryptoHelper : TencentCryptoHelper
{
    /// <summary>
    /// 初始化企业微信加解密工具
    /// </summary>
    /// <param name="token">回调配置中的 Token</param>
    /// <param name="encodingAesKey">回调配置中的 EncodingAESKey（43 位字符）</param>
    /// <param name="corpId">企业 ID</param>
    public WecomCryptoHelper(string token, string encodingAesKey, string corpId)
        : base(token, encodingAesKey, corpId) { }
}

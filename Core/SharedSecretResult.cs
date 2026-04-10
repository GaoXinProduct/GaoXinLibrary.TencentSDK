using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 统一共享密钥接口响应
/// <para>
/// 由主服务器通过 <c>GetSharedSecretAsync()</c> 生成，包含加密后的 <see cref="SharedSecretPayload"/>。<br/>
/// 直接序列化后返回给备服务器即可，备服务器 SDK 通过 <c>SecretShareUrl</c> 自动拉取并解密。
/// </para>
/// </summary>
public sealed class SharedSecretResult
{
    /// <summary>
    /// 加密后的统一共享密钥载荷（ChaCha20-Poly1305，Base64 编码）
    /// <para>格式：<c>Base64( nonce[12] + ciphertext[N] + tag[16] )</c></para>
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; } = string.Empty;
}

using System.Security.Cryptography;
using System.Text;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯 SDK Token 共享加解密工具（ChaCha20-Poly1305）
/// <para>
/// 适用于多服务共享 access_token 场景：<br/>
/// 主服务（持有真实 AppSecret）通过 <see cref="Encrypt"/> 加密后对外暴露，
/// 从服务配置 <c>TokenShareUrl</c> 与 <c>ShareSecret</c> 后由 SDK 自动获取并解密。<br/>
/// 加密格式：<c>Base64( nonce[12] + ciphertext[N] + tag[16] )</c>
/// </para>
/// </summary>
public static class TencentTokenCrypto
{
    /// <summary>
    /// 加密 access_token（ChaCha20-Poly1305）
    /// </summary>
    /// <param name="token">明文 access_token</param>
    /// <param name="shareSecret">共享密钥（任意长度，内部通过 SHA-256 派生为 32 字节密钥）</param>
    /// <returns>Base64 编码的加密结果（nonce[12] + ciphertext[N] + tag[16]）</returns>
    public static string Encrypt(string token, string shareSecret)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);
        ArgumentException.ThrowIfNullOrWhiteSpace(shareSecret);
        return EncryptWithKey(token, DeriveKey(shareSecret));
    }

    /// <summary>
    /// 解密 access_token（ChaCha20-Poly1305）
    /// </summary>
    /// <param name="encrypted">Base64 编码的加密数据</param>
    /// <param name="shareSecret">共享密钥</param>
    /// <returns>明文 access_token</returns>
    public static string Decrypt(string encrypted, string shareSecret)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(encrypted);
        ArgumentException.ThrowIfNullOrWhiteSpace(shareSecret);
        return DecryptWithKey(encrypted, DeriveKey(shareSecret));
    }

    // ─── 内部方法（供 TencentAccessTokenProvider 直接使用派生好的 key 字节） ──────

    internal static byte[] DeriveKey(string shareSecret)
        => SHA256.HashData(Encoding.UTF8.GetBytes(shareSecret));

    internal static string EncryptWithKey(string token, byte[] key)
    {
        var nonce = RandomNumberGenerator.GetBytes(12);
        var plaintext = Encoding.UTF8.GetBytes(token);
        var ciphertext = new byte[plaintext.Length];
        var tag = new byte[16];

        using var chacha = new ChaCha20Poly1305(key);
        chacha.Encrypt(nonce, plaintext, ciphertext, tag);

        // combined = nonce(12) + ciphertext(N) + tag(16)
        var combined = new byte[12 + ciphertext.Length + 16];
        nonce.CopyTo(combined, 0);
        ciphertext.CopyTo(combined, 12);
        tag.CopyTo(combined, 12 + ciphertext.Length);
        return Convert.ToBase64String(combined);
    }

    internal static string DecryptWithKey(string encrypted, byte[] key)
    {
        byte[] data;
        try
        {
            data = Convert.FromBase64String(encrypted);
        }
        catch
        {
            throw new TencentException("共享 Token 解密失败：Base64 格式无效");
        }

        // 最小长度：12(nonce) + 0(空 token，理论不存在但防御) + 16(tag) = 28
        if (data.Length < 28)
            throw new TencentException("共享 Token 解密失败：数据长度不足");

        var nonce = data.AsSpan(0, 12);
        var tag = data.AsSpan(data.Length - 16, 16);
        var ciphertext = data.AsSpan(12, data.Length - 28);
        var plaintext = new byte[ciphertext.Length];

        using var chacha = new ChaCha20Poly1305(key);
        try
        {
            chacha.Decrypt(nonce, ciphertext, tag, plaintext);
        }
        catch (Exception ex)
        {
            throw new TencentException($"共享 Token 解密失败：{ex.Message}");
        }

        return Encoding.UTF8.GetString(plaintext);
    }
}

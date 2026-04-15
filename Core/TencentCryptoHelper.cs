using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台消息加解密基类
/// <para>
/// 封装微信公众号与企业微信共用的回调消息签名校验、AES-256-CBC 加解密流程。
/// </para>
/// </summary>
public abstract class TencentCryptoHelper
{
    private readonly string _token;
    private readonly byte[] _aesKey;
    private readonly string _receiverId;

    /// <summary>
    /// 初始化加解密工具
    /// </summary>
    /// <param name="token">回调配置中的 Token</param>
    /// <param name="encodingAesKey">回调配置中的 EncodingAESKey（43 位字符）</param>
    /// <param name="receiverId">接收方标识（企业微信为 CorpId，微信为 AppId）</param>
    protected TencentCryptoHelper(string token, string encodingAesKey, string receiverId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);
        ArgumentException.ThrowIfNullOrWhiteSpace(encodingAesKey);
        ArgumentException.ThrowIfNullOrWhiteSpace(receiverId);

        _token = token;
        _receiverId = receiverId;
        // EncodingAESKey 是 Base64 编码后去掉末尾 '=' 的 43 位字符串，还原为 32 字节密钥
        _aesKey = Convert.FromBase64String(encodingAesKey + "=");
    }

    /// <summary>
    /// 创建异常实例
    /// </summary>
    /// <param name="message">异常消息</param>
    protected static TencentException CreateException(string message) => new(message);

    #region 签名校验

    /// <summary>
    /// 校验消息签名
    /// </summary>
    /// <param name="signature">URL 参数中的 signature 或 msg_signature</param>
    /// <param name="timestamp">URL 参数中的 timestamp</param>
    /// <param name="nonce">URL 参数中的 nonce</param>
    /// <param name="encrypt">加密消息体（明文模式下可为 null）</param>
    /// <returns>签名是否合法</returns>
    public bool VerifySignature(string signature, string timestamp, string nonce, string? encrypt = null)
    {
        var computed = ComputeSignature(timestamp, nonce, encrypt);
        return string.Equals(computed, signature, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// 计算消息签名（SHA1）
    /// </summary>
    public string ComputeSignature(string timestamp, string nonce, string? encrypt = null)
    {
        string[] arr = encrypt is null
            ? [_token, timestamp, nonce]
            : [_token, timestamp, nonce, encrypt];
        Array.Sort(arr, StringComparer.Ordinal);
        var raw = string.Concat(arr);
        var byteCount = Encoding.UTF8.GetByteCount(raw);
        Span<byte> utf8 = byteCount <= 512 ? stackalloc byte[byteCount] : new byte[byteCount];
        Encoding.UTF8.GetBytes(raw, utf8);
        Span<byte> hash = stackalloc byte[20];
        SHA1.HashData(utf8, hash);
        return HexHelper.ToLowerHex(hash);
    }

    #endregion
    #region 解密

    /// <summary>
    /// 解密回调消息
    /// </summary>
    /// <param name="encryptedBase64">Base64 编码的加密消息</param>
    /// <returns>解密后的 XML 明文</returns>
    public string Decrypt(string encryptedBase64)
    {
        var encrypted = Convert.FromBase64String(encryptedBase64);

        // AES-256-CBC，IV 取 AES Key 前 16 字节
        var iv = _aesKey[..16];
        using var aes = Aes.Create();
        aes.Key = _aesKey;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;

        using var decryptor = aes.CreateDecryptor();
        var decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);

        // 去除 PKCS#7 填充
        var pad = decrypted[^1];
        if (pad < 1 || pad > 32)
            throw CreateException("消息解密失败：PKCS#7 填充无效");

        var contentLen = decrypted.Length - pad;

        // 前 16 字节为随机字符串，跳过
        // 接下来 4 字节为消息长度（网络字节序）
        var span = decrypted.AsSpan();
        var msgLen = BinaryPrimitives.ReadInt32BigEndian(span.Slice(16, 4));
        var msgSpan = span.Slice(20, msgLen);

        // 验证接收方标识（CorpId / AppId）
        var receivedId = Encoding.UTF8.GetString(span.Slice(20 + msgLen, contentLen - 20 - msgLen));
        if (!string.Equals(receivedId, _receiverId, StringComparison.Ordinal))
            throw CreateException($"消息解密失败：接收方标识不匹配（期望 {_receiverId}，实际 {receivedId}）");

        return Encoding.UTF8.GetString(msgSpan);
    }

    #endregion
    #region 加密

    /// <summary>
    /// 加密被动回复消息
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文</param>
    /// <returns>Base64 编码的加密消息</returns>
    public string Encrypt(string replyXml)
    {
        var randomBytes = RandomNumberGenerator.GetBytes(16);
        var msgBytes = Encoding.UTF8.GetBytes(replyXml);
        var receiverIdBytes = Encoding.UTF8.GetBytes(_receiverId);

        // 拼接 random(16) + msgLen(4) + msg + receiverId
        var plainLen = 16 + 4 + msgBytes.Length + receiverIdBytes.Length;
        // PKCS#7 填充
        var amountToPad = 32 - (plainLen % 32);
        if (amountToPad == 0) amountToPad = 32;

        var padded = new byte[plainLen + amountToPad];
        var paddedSpan = padded.AsSpan();
        randomBytes.CopyTo(paddedSpan);
        BinaryPrimitives.WriteInt32BigEndian(paddedSpan.Slice(16, 4), msgBytes.Length);
        msgBytes.CopyTo(paddedSpan[20..]);
        receiverIdBytes.CopyTo(paddedSpan[(20 + msgBytes.Length)..]);
        paddedSpan[plainLen..].Fill((byte)amountToPad);

        var iv = _aesKey[..16];
        using var aes = Aes.Create();
        aes.Key = _aesKey;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;

        using var encryptor = aes.CreateEncryptor();
        var encrypted = encryptor.TransformFinalBlock(padded, 0, padded.Length);
        return Convert.ToBase64String(encrypted);
    }

    #endregion
    #region 辅助方法

    /// <summary>
    /// 验证 URL 回调（GET 请求）：校验签名并解密返回 echostr 明文
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr（加密的随机字符串）</param>
    /// <returns>解密后的 echostr 明文（应直接返回给服务器）</returns>
    public string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        if (!VerifySignature(msgSignature, timestamp, nonce, echoStr))
            throw CreateException("回调 URL 验证失败：签名不匹配");

        return Decrypt(echoStr);
    }

    /// <summary>
    /// 解密回调 POST 请求体（XML 格式）
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串</param>
    /// <returns>解密后的 XML 明文</returns>
    public string DecryptMessage(string msgSignature, string timestamp, string nonce, string postBody)
    {
        var doc = XDocument.Parse(postBody);
        var encrypt = doc.Root?.Element("Encrypt")?.Value
                      ?? throw CreateException("回调消息解密失败：缺少 Encrypt 节点");

        if (!VerifySignature(msgSignature, timestamp, nonce, encrypt))
            throw CreateException("回调消息解密失败：签名不匹配");

        return Decrypt(encrypt);
    }

    /// <summary>
    /// 加密被动回复消息并生成完整的回复 XML
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文</param>
    /// <param name="timestamp">时间戳</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML</returns>
    public string EncryptReply(string replyXml, string timestamp, string nonce)
    {
        var encrypted = Encrypt(replyXml);
        var signature = ComputeSignature(timestamp, nonce, encrypted);

        return $"""
            <xml>
            <Encrypt><![CDATA[{encrypted}]]></Encrypt>
            <MsgSignature><![CDATA[{signature}]]></MsgSignature>
            <TimeStamp>{timestamp}</TimeStamp>
            <Nonce><![CDATA[{nonce}]]></Nonce>
            </xml>
            """;
    }
    #endregion
}

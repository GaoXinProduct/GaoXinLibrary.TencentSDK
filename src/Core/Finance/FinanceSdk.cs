using System.Runtime.InteropServices;
using System.Security.Cryptography;
using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core.Finance;

/// <summary>
/// 企业微信会话内容存档 C SDK 托管封装
/// <para>
/// 封装原生 SDK 的生命周期管理、会话数据拉取、媒体文件下载和消息解密等功能。
/// 使用前需将对应平台的原生库放置到应用程序输出目录中：
/// <list type="bullet">
///   <item>Linux: <c>libWeWorkFinanceSdk_C.so</c></item>
///   <item>Windows: <c>WeWorkFinanceSdk_C.dll</c></item>
/// </list>
/// </para>
/// </summary>
public sealed class FinanceSdk : IDisposable
{
    private nint _sdk;
    private bool _disposed;

    /// <summary>
    /// 创建并初始化会话内容存档 SDK
    /// </summary>
    /// <param name="corpId">企业 ID</param>
    /// <param name="secret">会话内容存档密钥（非应用 CorpSecret）</param>
    /// <exception cref="TencentException">初始化失败时抛出</exception>
    public FinanceSdk(string corpId, string secret)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(corpId);
        ArgumentException.ThrowIfNullOrWhiteSpace(secret);

        _sdk = FinanceNativeMethods.NewSdk();
        if (_sdk == 0)
            throw new TencentException("会话内容存档 SDK 创建失败");

        var ret = FinanceNativeMethods.Init(_sdk, corpId, secret);
        if (ret != 0)
        {
            FinanceNativeMethods.DestroySdk(_sdk);
            _sdk = 0;
            throw new TencentException(ret, $"会话内容存档 SDK 初始化失败，错误码: {ret}", "企业微信");
        }
    }

    /// <summary>
    /// 拉取会话记录数据（JSON 格式）
    /// </summary>
    /// <param name="seq">从指定的 seq 开始拉取消息（返回的消息从 seq+1 开始），首次传 0</param>
    /// <param name="limit">一次拉取的消息条数，最大值 1000，超过会返回错误</param>
    /// <param name="proxy">代理地址（如 <c>socks5://ip:port</c>），不使用代理传空字符串</param>
    /// <param name="passwd">代理账号密码，不使用代理传空字符串</param>
    /// <param name="timeout">超时时间（秒），建议 5</param>
    /// <returns>会话记录 JSON 字符串（包含 chatdata 数组）</returns>
    /// <exception cref="TencentException">拉取失败时抛出</exception>
    public string GetChatData(ulong seq, uint limit = 1000, string proxy = "", string passwd = "", int timeout = 5)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        var slice = FinanceNativeMethods.NewSlice();
        try
        {
            var ret = FinanceNativeMethods.GetChatData(_sdk, seq, limit, proxy, passwd, timeout, slice);
            if (ret != 0)
                throw new TencentException(ret, $"拉取会话记录失败，错误码: {ret}", "企业微信");

            return GetStringFromSlice(slice);
        }
        finally
        {
            FinanceNativeMethods.FreeSlice(slice);
        }
    }

    /// <summary>
    /// 解密单条消息的加密内容
    /// <para>
    /// 完整流程：
    /// 1. 使用 RSA 私钥解密 encrypt_random_key 得到消息密钥（encrypt_key）
    /// 2. 将 encrypt_key 和 encrypt_chat_msg 传入原生 SDK 解密得到明文
    /// </para>
    /// </summary>
    /// <param name="privateKeyPem">RSA 私钥（PEM 格式），对应配置在企业微信管理台的 RSA 公钥</param>
    /// <param name="encryptRandomKey">消息中的 encrypt_random_key 字段</param>
    /// <param name="encryptChatMsg">消息中的 encrypt_chat_msg 字段</param>
    /// <returns>解密后的消息明文 JSON</returns>
    /// <exception cref="TencentException">解密失败时抛出</exception>
    public static string DecryptChatMessage(string privateKeyPem, string encryptRandomKey, string encryptChatMsg)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(privateKeyPem);
        ArgumentException.ThrowIfNullOrWhiteSpace(encryptRandomKey);
        ArgumentException.ThrowIfNullOrWhiteSpace(encryptChatMsg);

        // 步骤 1：使用 RSA 私钥解密 encrypt_random_key 得到 encrypt_key
        string encryptKey;
        try
        {
            using var rsa = RSA.Create();
            rsa.ImportFromPem(privateKeyPem);
            var encryptedBytes = Convert.FromBase64String(encryptRandomKey);
            var decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
            encryptKey = System.Text.Encoding.UTF8.GetString(decryptedBytes);
        }
        catch (Exception ex) when (ex is not TencentException)
        {
            throw new TencentException($"RSA 解密 encrypt_random_key 失败: {ex.Message}", ex);
        }

        // 步骤 2：将解密后的密钥和加密消息传入原生 SDK 解密
        var slice = FinanceNativeMethods.NewSlice();
        try
        {
            var ret = FinanceNativeMethods.DecryptData(encryptKey, encryptChatMsg, slice);
            if (ret != 0)
                throw new TencentException(ret, $"解密会话消息失败，错误码: {ret}", "企业微信");

            return GetStringFromSlice(slice);
        }
        finally
        {
            FinanceNativeMethods.FreeSlice(slice);
        }
    }

    /// <summary>
    /// 下载媒体文件数据
    /// <para>对于大文件会自动分片拉取并合并。</para>
    /// </summary>
    /// <param name="sdkFileId">消息中的 sdkfileid 字段</param>
    /// <param name="proxy">代理地址，不使用代理传空字符串</param>
    /// <param name="passwd">代理密码，不使用代理传空字符串</param>
    /// <param name="timeout">超时时间（秒），建议 5</param>
    /// <returns>媒体文件的完整字节数据</returns>
    /// <exception cref="TencentException">下载失败时抛出</exception>
    public unsafe byte[] GetMediaData(string sdkFileId, string proxy = "", string passwd = "", int timeout = 5)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(sdkFileId);

        using var ms = new MemoryStream();
        var indexBuf = string.Empty;

        while (true)
        {
            var mediaData = FinanceNativeMethods.NewMediaData();
            try
            {
                var ret = FinanceNativeMethods.GetMediaData(_sdk, indexBuf, sdkFileId, proxy, passwd, timeout, mediaData);
                if (ret != 0)
                    throw new TencentException(ret, $"下载媒体文件失败，错误码: {ret}", "企业微信");

                var dataPtr = FinanceNativeMethods.GetData(mediaData);
                var dataLen = FinanceNativeMethods.GetDataLen(mediaData);
                if (dataLen > 0 && dataPtr != 0)
                {
                    var span = new ReadOnlySpan<byte>((void*)dataPtr, dataLen);
                    ms.Write(span);
                }

                // is_finish: 0 表示拉取完成，非 0 表示未完成需继续
                var isFinish = FinanceNativeMethods.IsMediaDataFinish(mediaData);
                if (isFinish == 0)
                    break;

                // 获取下次拉取需要使用的 indexbuf
                var outIndexPtr = FinanceNativeMethods.GetOutIndexBuf(mediaData);
                indexBuf = outIndexPtr != 0 ? Marshal.PtrToStringUTF8(outIndexPtr) ?? string.Empty : string.Empty;
            }
            finally
            {
                FinanceNativeMethods.FreeMediaData(mediaData);
            }
        }

        return ms.ToArray();
    }

    /// <summary>
    /// 下载媒体文件并写入流
    /// <para>适用于大文件场景，避免一次性加载到内存。</para>
    /// </summary>
    /// <param name="sdkFileId">消息中的 sdkfileid 字段</param>
    /// <param name="destination">目标输出流</param>
    /// <param name="proxy">代理地址</param>
    /// <param name="passwd">代理密码</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <exception cref="TencentException">下载失败时抛出</exception>
    public unsafe void GetMediaData(string sdkFileId, Stream destination, string proxy = "", string passwd = "", int timeout = 5)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(sdkFileId);
        ArgumentNullException.ThrowIfNull(destination);

        var indexBuf = string.Empty;
        while (true)
        {
            var mediaData = FinanceNativeMethods.NewMediaData();
            try
            {
                var ret = FinanceNativeMethods.GetMediaData(_sdk, indexBuf, sdkFileId, proxy, passwd, timeout, mediaData);
                if (ret != 0)
                    throw new TencentException(ret, $"下载媒体文件失败，错误码: {ret}", "企业微信");

                var dataPtr = FinanceNativeMethods.GetData(mediaData);
                var dataLen = FinanceNativeMethods.GetDataLen(mediaData);
                if (dataLen > 0 && dataPtr != 0)
                {
                    var span = new ReadOnlySpan<byte>((void*)dataPtr, dataLen);
                    destination.Write(span);
                }

                // is_finish: 0 表示拉取完成，非 0 表示未完成需继续
                var isFinish = FinanceNativeMethods.IsMediaDataFinish(mediaData);
                if (isFinish == 0)
                    break;

                var outIndexPtr = FinanceNativeMethods.GetOutIndexBuf(mediaData);
                indexBuf = outIndexPtr != 0 ? Marshal.PtrToStringUTF8(outIndexPtr) ?? string.Empty : string.Empty;
            }
            finally
            {
                FinanceNativeMethods.FreeMediaData(mediaData);
            }
        }
    }

    private static string GetStringFromSlice(nint slice)
    {
        var contentPtr = FinanceNativeMethods.GetContentFromSlice(slice);
        var len = FinanceNativeMethods.GetSliceLen(slice);
        if (contentPtr == 0 || len <= 0)
            return string.Empty;

        return Marshal.PtrToStringUTF8(contentPtr, len) ?? string.Empty;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        if (_sdk != 0)
        {
            FinanceNativeMethods.DestroySdk(_sdk);
            _sdk = 0;
        }
    }
}

using System.Runtime.InteropServices;

namespace GaoXinLibrary.TencentSDK.Wecom.Core.Finance;

/// <summary>
/// 企业微信会话内容存档 C SDK 原生方法声明
/// <para>
/// 对应企业微信提供的 <c>libWeWorkFinanceSdk_C.so</c>（Linux）或
/// <c>WeWorkFinanceSdk_C.dll</c>（Windows）原生库。
/// 使用前需将对应平台的原生库放置到应用程序输出目录中。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/91774"/>
/// </para>
/// </summary>
internal static class FinanceNativeMethods
{
    private const string DllName = "WeWorkFinanceSdk_C";

    /// <summary>创建 SDK 实例，返回句柄指针</summary>
    [DllImport(DllName, EntryPoint = "NewSdk")]
    internal static extern nint NewSdk();

    /// <summary>
    /// 初始化 SDK
    /// </summary>
    /// <param name="sdk">SDK 句柄</param>
    /// <param name="corpId">企业 ID</param>
    /// <param name="secret">会话内容存档密钥</param>
    /// <returns>0 表示成功，非 0 表示失败</returns>
    [DllImport(DllName, EntryPoint = "Init", CharSet = CharSet.Ansi)]
    internal static extern int Init(nint sdk, string corpId, string secret);

    /// <summary>
    /// 拉取会话记录数据
    /// </summary>
    /// <param name="sdk">SDK 句柄</param>
    /// <param name="seq">从指定的 seq 开始拉取消息（返回的消息从 seq+1 开始），首次传 0</param>
    /// <param name="limit">一次拉取的消息条数，最大值 1000</param>
    /// <param name="proxy">代理地址（如 socks5://10.0.0.1:8081），无代理传空字符串</param>
    /// <param name="passwd">代理账号密码（如 user:passwd），无需传空字符串</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="chatData">接收返回数据的 Slice 指针（由 NewSlice 创建）</param>
    /// <returns>0 表示成功</returns>
    [DllImport(DllName, EntryPoint = "GetChatData", CharSet = CharSet.Ansi)]
    internal static extern int GetChatData(nint sdk, ulong seq, uint limit, string proxy, string passwd, int timeout, nint chatData);

    /// <summary>
    /// 拉取媒体文件数据（分片拉取，每次最大 512K）
    /// </summary>
    /// <param name="sdk">SDK 句柄</param>
    /// <param name="indexBuf">分片索引，首次传空字符串，后续传上次返回的 outindexbuf</param>
    /// <param name="sdkFileId">从解密后消息中获取的 sdkfileid</param>
    /// <param name="proxy">代理地址（如 socks5://10.0.0.1:8081），无代理传空字符串</param>
    /// <param name="passwd">代理账号密码，无需传空字符串</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="mediaData">接收返回媒体数据的指针（由 NewMediaData 创建）</param>
    /// <returns>0 表示成功</returns>
    [DllImport(DllName, EntryPoint = "GetMediaData", CharSet = CharSet.Ansi)]
    internal static extern int GetMediaData(nint sdk, string indexBuf, string sdkFileId, string proxy, string passwd, int timeout, nint mediaData);

    /// <summary>
    /// 解密会话存档消息内容
    /// <para>
    /// 需先用 RSA 私钥解密 encrypt_random_key 得到 encrypt_key，
    /// 再将 encrypt_key 和 encrypt_chat_msg 传入本方法进行解密。
    /// </para>
    /// </summary>
    /// <param name="encryptKey">用 RSA 私钥解密 encrypt_random_key 后得到的密钥</param>
    /// <param name="encryptChatMsg">GetChatData 返回的 encrypt_chat_msg</param>
    /// <param name="msg">接收解密后消息明文的 Slice 指针（由 NewSlice 创建）</param>
    /// <returns>0 表示成功</returns>
    [DllImport(DllName, EntryPoint = "DecryptData", CharSet = CharSet.Ansi)]
    internal static extern int DecryptData(string encryptKey, string encryptChatMsg, nint msg);

    /// <summary>释放 SDK 实例</summary>
    [DllImport(DllName, EntryPoint = "DestroySdk")]
    internal static extern void DestroySdk(nint sdk);

    // ─── Slice（文本数据容器）───────────────────────────────────────────

    /// <summary>创建文本数据容器</summary>
    [DllImport(DllName, EntryPoint = "NewSlice")]
    internal static extern nint NewSlice();

    /// <summary>释放文本数据容器</summary>
    [DllImport(DllName, EntryPoint = "FreeSlice")]
    internal static extern void FreeSlice(nint slice);

    /// <summary>获取文本数据容器的内容指针</summary>
    [DllImport(DllName, EntryPoint = "GetContentFromSlice")]
    internal static extern nint GetContentFromSlice(nint slice);

    /// <summary>获取文本数据容器的内容长度</summary>
    [DllImport(DllName, EntryPoint = "GetSliceLen")]
    internal static extern int GetSliceLen(nint slice);

    // ─── MediaData（媒体数据容器）─────────────────────────────────────

    /// <summary>创建媒体数据容器</summary>
    [DllImport(DllName, EntryPoint = "NewMediaData")]
    internal static extern nint NewMediaData();

    /// <summary>释放媒体数据容器</summary>
    [DllImport(DllName, EntryPoint = "FreeMediaData")]
    internal static extern void FreeMediaData(nint mediaData);

    /// <summary>获取媒体数据内容指针（对应 MediaData_t.data）</summary>
    [DllImport(DllName, EntryPoint = "GetData")]
    internal static extern nint GetData(nint mediaData);

    /// <summary>获取媒体数据 outindexbuf 的长度（对应 MediaData_t.out_len）</summary>
    [DllImport(DllName, EntryPoint = "GetIndexLen")]
    internal static extern int GetIndexLen(nint mediaData);

    /// <summary>获取媒体数据内容的长度（对应 MediaData_t.data_len）</summary>
    [DllImport(DllName, EntryPoint = "GetDataLen")]
    internal static extern int GetDataLen(nint mediaData);

    /// <summary>获取媒体数据的 outindexbuf（用于分片续传）</summary>
    [DllImport(DllName, EntryPoint = "GetOutIndexBuf")]
    internal static extern nint GetOutIndexBuf(nint mediaData);

    /// <summary>判断媒体数据是否拉取完毕：0-已完成 非0-未完成</summary>
    [DllImport(DllName, EntryPoint = "IsMediaDataFinish")]
    internal static extern int IsMediaDataFinish(nint mediaData);
}

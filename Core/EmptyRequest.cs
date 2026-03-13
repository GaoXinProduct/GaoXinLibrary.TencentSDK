namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>空请求体，序列化为 <c>{}</c></summary>
public sealed class EmptyRequest
{
    /// <summary>共享单例实例</summary>
    public static readonly EmptyRequest Instance = new();
}

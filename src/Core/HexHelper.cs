namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 十六进制转换辅助类（提供跨 TFM 兼容的小写十六进制输出）
/// </summary>
internal static class HexHelper
{
    /// <summary>将字节序列转换为小写十六进制字符串</summary>
    internal static string ToLowerHex(ReadOnlySpan<byte> bytes)
    {
#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(bytes);
#else
        return string.Create(bytes.Length * 2, bytes.ToArray(), static (chars, src) =>
        {
            for (var i = 0; i < src.Length; i++)
            {
                var b = src[i];
                chars[i * 2] = ToLowerHexChar(b >> 4);
                chars[i * 2 + 1] = ToLowerHexChar(b & 0xF);
            }
        });
#endif
    }

#if !NET9_0_OR_GREATER
    private static char ToLowerHexChar(int value) => (char)(value < 10 ? '0' + value : 'a' + value - 10);
#endif
}

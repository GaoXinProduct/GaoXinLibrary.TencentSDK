namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台 API 调用异常
/// </summary>
public class TencentException : Exception
{
    /// <summary>平台错误码（errcode）</summary>
    public int ErrCode { get; }

    /// <summary>平台错误信息（errmsg）</summary>
    public string ErrMsg { get; }

    /// <summary>
    /// 使用错误码和错误信息创建异常
    /// </summary>
    public TencentException(int errCode, string errMsg, string? platformName = null)
        : base(platformName is null
            ? $"API 调用失败：[{errCode}] {errMsg}"
            : $"{platformName} API 调用失败：[{errCode}] {errMsg}")
    {
        ErrCode = errCode;
        ErrMsg = errMsg;
    }

    /// <summary>
    /// 使用消息字符串创建异常
    /// </summary>
    public TencentException(string message, Exception? inner = null)
        : base(message, inner)
    {
        ErrCode = -1;
        ErrMsg = message;
    }
}

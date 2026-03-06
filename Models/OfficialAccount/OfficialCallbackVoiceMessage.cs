using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>语音消息</summary>
public class OfficialCallbackVoiceMessage : OfficialCallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>语音消息媒体 ID</summary>
    public string MediaId { get; set; } = string.Empty;

    /// <summary>语音格式（如 amr / speex）</summary>
    public string Format { get; set; } = string.Empty;

    /// <summary>语音识别结果（开通语音识别后才有）</summary>
    public string? Recognition { get; set; }

    /// <summary>消息的数据ID</summary>
    public string? MsgDataId { get; set; }

    /// <summary>多图文时第几篇文章，从1开始</summary>
    public string? Idx { get; set; }
}


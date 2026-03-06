using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>语音消息</summary>
public class CallbackVoiceMessage : CallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>语音媒体文件 ID</summary>
    public string MediaId { get; set; } = string.Empty;

    /// <summary>语音格式，如 amr / speex 等</summary>
    public string Format { get; set; } = string.Empty;
}


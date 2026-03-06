using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>视频/小视频消息</summary>
public class CallbackVideoMessage : CallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>视频媒体文件 ID</summary>
    public string MediaId { get; set; } = string.Empty;

    /// <summary>视频消息缩略图的媒体 ID</summary>
    public string ThumbMediaId { get; set; } = string.Empty;
}


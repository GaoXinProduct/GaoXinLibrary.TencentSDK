using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>视频消息 / 小视频消息</summary>
public class OfficialCallbackVideoMessage : OfficialCallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>视频消息媒体 ID</summary>
    public string MediaId { get; set; } = string.Empty;

    /// <summary>视频消息缩略图的媒体 ID</summary>
    public string ThumbMediaId { get; set; } = string.Empty;

    /// <summary>消息的数据ID</summary>
    public string? MsgDataId { get; set; }

    /// <summary>多图文时第几篇文章，从1开始</summary>
    public string? Idx { get; set; }
}


using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图片消息</summary>
public class OfficialCallbackImageMessage : OfficialCallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>图片链接（由系统生成）</summary>
    public string PicUrl { get; set; } = string.Empty;

    /// <summary>图片消息媒体 ID（可调用获取临时素材接口拉取数据）</summary>
    public string MediaId { get; set; } = string.Empty;

    /// <summary>消息的数据ID</summary>
    public string? MsgDataId { get; set; }

    /// <summary>多图文时第几篇文章，从1开始</summary>
    public string? Idx { get; set; }
}


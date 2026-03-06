using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>地理位置消息</summary>
public class OfficialCallbackLocationMessage : OfficialCallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>地理位置纬度</summary>
    public double LocationX { get; set; }

    /// <summary>地理位置经度</summary>
    public double LocationY { get; set; }

    /// <summary>地图缩放大小</summary>
    public int Scale { get; set; }

    /// <summary>地理位置信息</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>消息的数据ID</summary>
    public string? MsgDataId { get; set; }

    /// <summary>多图文时第几篇文章，从1开始</summary>
    public string? Idx { get; set; }
}


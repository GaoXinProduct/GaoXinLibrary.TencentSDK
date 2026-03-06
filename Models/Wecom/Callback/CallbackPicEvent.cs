using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>弹出拍照或者相册发图/弹出微信相册发图器事件</summary>
public class CallbackPicEvent : CallbackEventBase
{
    /// <summary>事件 KEY 值</summary>
    public string EventKey { get; set; } = string.Empty;

    /// <summary>发送的图片数量</summary>
    public int Count { get; set; }

    /// <summary>图片 MD5 列表</summary>
    public string[]? PicMd5Sums { get; set; }
}


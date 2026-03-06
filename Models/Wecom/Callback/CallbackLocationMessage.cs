using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>位置消息</summary>
public class CallbackLocationMessage : CallbackMessageBase
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

    /// <summary>app类型（为固定值 "Work"）</summary>
    public string? AppType { get; set; }
}


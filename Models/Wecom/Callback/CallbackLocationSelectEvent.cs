using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>弹出地理位置选择器事件</summary>
public class CallbackLocationSelectEvent : CallbackEventBase
{
    /// <summary>事件 KEY 值</summary>
    public string EventKey { get; set; } = string.Empty;

    /// <summary>纬度</summary>
    public double LocationX { get; set; }

    /// <summary>经度</summary>
    public double LocationY { get; set; }

    /// <summary>缩放大小</summary>
    public int Scale { get; set; }

    /// <summary>地理位置信息</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>POI 名称</summary>
    public string? PoiName { get; set; }
}


using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>上报地理位置事件</summary>
public class CallbackLocationEvent : CallbackEventBase
{
    /// <summary>地理位置纬度</summary>
    public double Latitude { get; set; }

    /// <summary>地理位置经度</summary>
    public double Longitude { get; set; }

    /// <summary>地理位置精度</summary>
    public double Precision { get; set; }
}


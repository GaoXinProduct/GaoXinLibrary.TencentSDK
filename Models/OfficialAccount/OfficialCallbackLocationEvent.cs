using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 上报地理位置事件
/// <para>Event = LOCATION</para>
/// </summary>
public class OfficialCallbackLocationEvent : OfficialCallbackEventBase
{
    /// <summary>地理位置纬度</summary>
    public double Latitude { get; set; }

    /// <summary>地理位置经度</summary>
    public double Longitude { get; set; }

    /// <summary>地理位置精度</summary>
    public double Precision { get; set; }
}


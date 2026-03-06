using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>扫码推事件/扫码推事件且弹出"消息接收中"事件</summary>
public class CallbackScanCodeEvent : CallbackEventBase
{
    /// <summary>事件 KEY 值</summary>
    public string EventKey { get; set; } = string.Empty;

    /// <summary>扫描类型（qrcode / barcode）</summary>
    public string? ScanType { get; set; }

    /// <summary>扫描结果</summary>
    public string? ScanResult { get; set; }
}


using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>点击菜单拉取消息事件</summary>
public class CallbackClickEvent : CallbackEventBase
{
    /// <summary>事件 KEY 值（与自定义菜单接口中 KEY 值对应）</summary>
    public string EventKey { get; set; } = string.Empty;
}


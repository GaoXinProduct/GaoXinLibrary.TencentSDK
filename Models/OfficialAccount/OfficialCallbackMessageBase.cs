using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 微信公众号回调消息基类
/// <para>所有接收到的消息和事件都继承此类</para>
/// </summary>
public class OfficialCallbackMessageBase
{
    /// <summary>开发者微信号（公众号原始 ID）</summary>
    public string ToUserName { get; set; } = string.Empty;

    /// <summary>发送方帐号（一个 OpenID）</summary>
    public string FromUserName { get; set; } = string.Empty;

    /// <summary>消息创建时间（Unix 时间戳）</summary>
    public long CreateTime { get; set; }

    /// <summary>消息类型（text / image / voice / video / shortvideo / location / link / event）</summary>
    public string MsgType { get; set; } = string.Empty;

    /// <summary>从 XML 解析消息（支持明文和解密后的 XML）</summary>
    public static OfficialCallbackMessageBase FromXml(string xml)
    {
        var doc = XDocument.Parse(xml);
        var root = doc.Root ?? throw new TencentException("无效的回调 XML：缺少根节点");

        var msgType = root.Element("MsgType")?.Value ?? string.Empty;
        return msgType switch
        {
            "text" => ParseTextMessage(root),
            "image" => ParseImageMessage(root),
            "voice" => ParseVoiceMessage(root),
            "video" => ParseVideoMessage(root),
            "shortvideo" => ParseShortVideoMessage(root),
            "location" => ParseLocationMessage(root),
            "link" => ParseLinkMessage(root),
            "event" => ParseEvent(root),
            _ => ParseBase(root, msgType)
        };
    }

    #region 解析各消息类型

    private static OfficialCallbackTextMessage ParseTextMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackTextMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.Content = root.Element("Content")?.Value ?? string.Empty;
        msg.MsgDataId = root.Element("MsgDataId")?.Value;
        msg.Idx = root.Element("Idx")?.Value;
        return msg;
    }

    private static OfficialCallbackImageMessage ParseImageMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackImageMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.PicUrl = root.Element("PicUrl")?.Value ?? string.Empty;
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        msg.MsgDataId = root.Element("MsgDataId")?.Value;
        msg.Idx = root.Element("Idx")?.Value;
        return msg;
    }

    private static OfficialCallbackVoiceMessage ParseVoiceMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackVoiceMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        msg.Format = root.Element("Format")?.Value ?? string.Empty;
        msg.Recognition = root.Element("Recognition")?.Value;
        msg.MsgDataId = root.Element("MsgDataId")?.Value;
        msg.Idx = root.Element("Idx")?.Value;
        return msg;
    }

    private static OfficialCallbackVideoMessage ParseVideoMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackVideoMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        msg.ThumbMediaId = root.Element("ThumbMediaId")?.Value ?? string.Empty;
        msg.MsgDataId = root.Element("MsgDataId")?.Value;
        msg.Idx = root.Element("Idx")?.Value;
        return msg;
    }

    private static OfficialCallbackVideoMessage ParseShortVideoMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackVideoMessage>(root);
        msg.MsgType = "shortvideo";
        msg.MsgId = GetLong(root, "MsgId");
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        msg.ThumbMediaId = root.Element("ThumbMediaId")?.Value ?? string.Empty;
        return msg;
    }

    private static OfficialCallbackLocationMessage ParseLocationMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackLocationMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.LocationX = GetDouble(root, "Location_X");
        msg.LocationY = GetDouble(root, "Location_Y");
        msg.Scale = GetInt(root, "Scale");
        msg.Label = root.Element("Label")?.Value ?? string.Empty;
        msg.MsgDataId = root.Element("MsgDataId")?.Value;
        msg.Idx = root.Element("Idx")?.Value;
        return msg;
    }

    private static OfficialCallbackLinkMessage ParseLinkMessage(XElement root)
    {
        var msg = FillBase<OfficialCallbackLinkMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.Title = root.Element("Title")?.Value ?? string.Empty;
        msg.Description = root.Element("Description")?.Value ?? string.Empty;
        msg.Url = root.Element("Url")?.Value ?? string.Empty;
        msg.MsgDataId = root.Element("MsgDataId")?.Value;
        msg.Idx = root.Element("Idx")?.Value;
        return msg;
    }

    #endregion
    #region 解析事件

    private static OfficialCallbackMessageBase ParseEvent(XElement root)
    {
        var eventType = root.Element("Event")?.Value ?? string.Empty;
        return eventType.ToLowerInvariant() switch
        {
            "subscribe" => ParseSubscribeEvent(root),
            "unsubscribe" => FillEvent<OfficialCallbackSubscribeEvent>(root),
            "scan" => ParseScanEvent(root),
            "location" => ParseLocationEvent(root),
            "click" => ParseClickEvent(root),
            "view" => ParseViewEvent(root),
            "templatesendjobfinish" => ParseTemplateSendJobFinishEvent(root),
            "masssendjobfinish" => ParseMassSendJobFinishEvent(root),
            "qualification_verify_success" or "qualification_verify_fail"
                or "naming_verify_success" or "naming_verify_fail"
                or "annual_renew" or "verify_expired" => FillEvent<OfficialCallbackVerifyEvent>(root),
            _ => FillEvent<OfficialCallbackEventBase>(root)
        };
    }

    private static OfficialCallbackSubscribeEvent ParseSubscribeEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackSubscribeEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value;
        evt.Ticket = root.Element("Ticket")?.Value;
        return evt;
    }

    private static OfficialCallbackScanEvent ParseScanEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackScanEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        evt.Ticket = root.Element("Ticket")?.Value ?? string.Empty;
        return evt;
    }

    private static OfficialCallbackLocationEvent ParseLocationEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackLocationEvent>(root);
        evt.Latitude = GetDouble(root, "Latitude");
        evt.Longitude = GetDouble(root, "Longitude");
        evt.Precision = GetDouble(root, "Precision");
        return evt;
    }

    private static OfficialCallbackClickEvent ParseClickEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackClickEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        return evt;
    }

    private static OfficialCallbackViewEvent ParseViewEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackViewEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        evt.MenuId = root.Element("MenuId")?.Value;
        return evt;
    }

    private static OfficialCallbackTemplateSendJobFinishEvent ParseTemplateSendJobFinishEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackTemplateSendJobFinishEvent>(root);
        evt.MsgID = GetLong(root, "MsgID");
        evt.Status = root.Element("Status")?.Value ?? string.Empty;
        return evt;
    }

    private static OfficialCallbackMassSendJobFinishEvent ParseMassSendJobFinishEvent(XElement root)
    {
        var evt = FillEvent<OfficialCallbackMassSendJobFinishEvent>(root);
        evt.MsgID = GetLong(root, "MsgID");
        evt.Status = root.Element("Status")?.Value ?? string.Empty;
        evt.TotalCount = GetInt(root, "TotalCount");
        evt.FilterCount = GetInt(root, "FilterCount");
        evt.SentCount = GetInt(root, "SentCount");
        evt.ErrorCount = GetInt(root, "ErrorCount");
        return evt;
    }

    #endregion
    #region 解析辅助方法

    private static OfficialCallbackMessageBase ParseBase(XElement root, string msgType)
    {
        var msg = FillBase<OfficialCallbackMessageBase>(root);
        msg.MsgType = msgType;
        return msg;
    }

    private static T FillBase<T>(XElement root) where T : OfficialCallbackMessageBase, new()
    {
        return new T
        {
            ToUserName = root.Element("ToUserName")?.Value ?? string.Empty,
            FromUserName = root.Element("FromUserName")?.Value ?? string.Empty,
            CreateTime = GetLong(root, "CreateTime"),
            MsgType = root.Element("MsgType")?.Value ?? string.Empty
        };
    }

    private static T FillEvent<T>(XElement root) where T : OfficialCallbackEventBase, new()
    {
        var evt = FillBase<T>(root);
        evt.Event = root.Element("Event")?.Value ?? string.Empty;
        return evt;
    }

    private static long GetLong(XElement? root, string name)
        => long.TryParse(root?.Element(name)?.Value, out var v) ? v : 0;

    private static int GetInt(XElement? root, string name)
        => int.TryParse(root?.Element(name)?.Value, out var v) ? v : 0;

    private static double GetDouble(XElement? root, string name)
        => double.TryParse(root?.Element(name)?.Value, out var v) ? v : 0;
    #endregion
}


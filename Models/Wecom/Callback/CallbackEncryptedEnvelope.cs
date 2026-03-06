using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>企业微信回调 POST 请求体（加密 XML 信封）</summary>
public class CallbackEncryptedEnvelope
{
    /// <summary>企业微信发来的加密消息体</summary>
    public string Encrypt { get; set; } = string.Empty;

    /// <summary>企业微信的 CorpID（可能为空）</summary>
    public string? ToUserName { get; set; }

    /// <summary>应用的 AgentID（可能为空）</summary>
    public string? AgentID { get; set; }

    /// <summary>从 XML 解析信封</summary>
    public static CallbackEncryptedEnvelope FromXml(string xml)
    {
        var doc = XDocument.Parse(xml);
        var root = doc.Root ?? throw new TencentException("无效的回调 XML：缺少根节点");
        return new CallbackEncryptedEnvelope
        {
            Encrypt = root.Element("Encrypt")?.Value ?? string.Empty,
            ToUserName = root.Element("ToUserName")?.Value,
            AgentID = root.Element("AgentID")?.Value
        };
    }
}


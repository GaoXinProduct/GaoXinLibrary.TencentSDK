using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>发送消息响应</summary>
public class KfSendMsgResponse : WecomBaseResponse
{
    /// <summary>消息 id</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }
}


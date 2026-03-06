using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>发送事件响应消息响应</summary>
public class KfSendMsgOnEventResponse : WecomBaseResponse
{
    /// <summary>消息 id</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }
}


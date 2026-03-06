using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>变更会话状态响应</summary>
public class KfServiceStateTransResponse : WecomBaseResponse
{
    /// <summary>变更后的消息 msgcode</summary>
    [JsonPropertyName("msg_code")] public string? MsgCode { get; set; }
}


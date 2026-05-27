namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>取消群发消息发送请求</summary>
public sealed class CancelGroupMsgSendRequest
{
    /// <summary>群发消息 ID</summary>
    [JsonPropertyName("msgid")]
    public string MsgId { get; set; } = string.Empty;
}

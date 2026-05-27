namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>提醒群发消息发送请求</summary>
public sealed class RemindGroupMsgSendRequest
{
    /// <summary>群发消息 ID</summary>
    [JsonPropertyName("msgid")]
    public string MsgId { get; set; } = string.Empty;
}

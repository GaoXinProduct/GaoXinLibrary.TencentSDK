
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>撤回消息请求</summary>
public sealed class RecallMessageRequest
{
    /// <summary>消息 ID</summary>
    [JsonPropertyName("msgid")]
    public string MsgId { get; set; } = string.Empty;
}

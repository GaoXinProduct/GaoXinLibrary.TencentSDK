using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取邮件未读数响应</summary>
public class GetMailUnreadCountResponse : WecomBaseResponse
{
    /// <summary>未读邮件数</summary>
    [JsonPropertyName("unread_count")] public int UnreadCount { get; set; }
}

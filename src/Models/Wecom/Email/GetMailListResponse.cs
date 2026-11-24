using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>应用收件箱邮件列表。</summary>
public sealed class GetMailListResponse : WecomBaseResponse
{
    /// <summary>下一页游标。</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    /// <summary>是否还有更多数据，0 为否，1 为是。</summary>
    [JsonPropertyName("has_more")] public uint HasMore { get; set; }
    /// <summary>本页邮件。</summary>
    [JsonPropertyName("mail_list")] public MailListItem[]? MailList { get; set; }
}

/// <summary>收件箱中的一封邮件。</summary>
public sealed class MailListItem
{
    /// <summary>用于读取邮件内容的 ID。</summary>
    [JsonPropertyName("mail_id")] public string? MailId { get; set; }
}

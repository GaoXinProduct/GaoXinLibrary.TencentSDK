
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class AddMomentTaskRequest
{
    [JsonPropertyName("text")]
    public MomentText? Text { get; set; }

    [JsonPropertyName("attachments")]
    public MomentAttachment[]? Attachments { get; set; }

    [JsonPropertyName("visible_range")]
    public MomentVisibleRange? VisibleRange { get; set; }
}

public sealed class MomentText
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

public sealed class MomentAttachment
{
    [JsonPropertyName("msgtype")]
    public string MsgType { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public MomentMedia? Image { get; set; }

    [JsonPropertyName("video")]
    public MomentMedia? Video { get; set; }

    [JsonPropertyName("link")]
    public MomentLink? Link { get; set; }
}

public sealed class MomentMedia
{
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
}

public sealed class MomentLink
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("media_id")]
    public string? MediaId { get; set; }
}

public sealed class MomentVisibleRange
{
    [JsonPropertyName("sender_list")]
    public MomentSenderList? SenderList { get; set; }

    [JsonPropertyName("external_contact_list")]
    public MomentExternalContactList? ExternalContactList { get; set; }
}

public sealed class MomentSenderList
{
    [JsonPropertyName("user_list")]
    public string[]? UserList { get; set; }

    [JsonPropertyName("department_list")]
    public int[]? DepartmentList { get; set; }
}

public sealed class MomentExternalContactList
{
    [JsonPropertyName("tag_list")]
    public string[]? TagList { get; set; }
}

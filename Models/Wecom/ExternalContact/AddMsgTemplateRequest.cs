namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>创建企业群发请求</summary>
public sealed class AddMsgTemplateRequest
{
    [JsonPropertyName("chat_type")] public string ChatType { get; set; } = string.Empty;
    [JsonPropertyName("external_userid")] public string[]? ExternalUserId { get; set; }
    [JsonPropertyName("sender")] public string? Sender { get; set; }
    [JsonPropertyName("text")] public GroupMsgText? Text { get; set; }
    [JsonPropertyName("image")] public GroupMsgImage? Image { get; set; }
    [JsonPropertyName("link")] public GroupMsgLink? Link { get; set; }
    [JsonPropertyName("miniprogram")] public GroupMsgMiniProgram? MiniProgram { get; set; }
}

public sealed class GroupMsgText
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

public sealed class GroupMsgImage
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
    [JsonPropertyName("pic_url")] public string? PicUrl { get; set; }
}

public sealed class GroupMsgLink
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("picurl")] public string? PicUrl { get; set; }
    [JsonPropertyName("desc")] public string? Desc { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
}

public sealed class GroupMsgMiniProgram
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("pic_media_id")] public string PicMediaId { get; set; } = string.Empty;
    [JsonPropertyName("appid")] public string AppId { get; set; } = string.Empty;
    [JsonPropertyName("page")] public string Page { get; set; } = string.Empty;
}

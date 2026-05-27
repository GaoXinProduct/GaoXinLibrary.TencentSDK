namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>配置客户联系「联系我」方式请求</summary>
public sealed class AddContactWayRequest
{
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("scene")] public int Scene { get; set; }
    [JsonPropertyName("style")] public int Style { get; set; }
    [JsonPropertyName("remark")] public string? Remark { get; set; }
    [JsonPropertyName("skip_verify")] public bool SkipVerify { get; set; } = true;
    [JsonPropertyName("state")] public string? State { get; set; }
    [JsonPropertyName("user")] public string[]? User { get; set; }
    [JsonPropertyName("party")] public int[]? Party { get; set; }
    [JsonPropertyName("is_temp")] public bool IsTemp { get; set; }
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    [JsonPropertyName("chat_expires_in")] public int ChatExpiresIn { get; set; }
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
    [JsonPropertyName("conclusions")] public ContactWayConclusions? Conclusions { get; set; }
}

public sealed class ContactWayConclusions
{
    [JsonPropertyName("text")] public ContactWayText? Text { get; set; }
    [JsonPropertyName("image")] public ContactWayImage? Image { get; set; }
    [JsonPropertyName("link")] public ContactWayLink? Link { get; set; }
    [JsonPropertyName("miniprogram")] public ContactWayMiniProgram? MiniProgram { get; set; }
}

public sealed class ContactWayText
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

public sealed class ContactWayImage
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
    [JsonPropertyName("pic_url")] public string? PicUrl { get; set; }
}

public sealed class ContactWayLink
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("picurl")] public string? PicUrl { get; set; }
    [JsonPropertyName("desc")] public string? Desc { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
}

public sealed class ContactWayMiniProgram
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("pic_media_id")] public string PicMediaId { get; set; } = string.Empty;
    [JsonPropertyName("appid")] public string AppId { get; set; } = string.Empty;
    [JsonPropertyName("page")] public string Page { get; set; } = string.Empty;
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>添加入群欢迎语素材请求</summary>
public sealed class AddWelcomeTemplateRequest
{
    [JsonPropertyName("text")] public WelcomeMsgText? Text { get; set; }
    [JsonPropertyName("image")] public WelcomeMsgImage? Image { get; set; }
    [JsonPropertyName("link")] public WelcomeMsgLink? Link { get; set; }
    [JsonPropertyName("miniprogram")] public WelcomeMsgMiniProgram? MiniProgram { get; set; }
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
    [JsonPropertyName("notify")] public int Notify { get; set; } = 0;
}

public sealed class WelcomeMsgText
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

public sealed class WelcomeMsgImage
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
    [JsonPropertyName("pic_url")] public string? PicUrl { get; set; }
}

public sealed class WelcomeMsgLink
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("picurl")] public string? PicUrl { get; set; }
    [JsonPropertyName("desc")] public string? Desc { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
}

public sealed class WelcomeMsgMiniProgram
{
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("pic_media_id")] public string PicMediaId { get; set; } = string.Empty;
    [JsonPropertyName("appid")] public string AppId { get; set; } = string.Empty;
    [JsonPropertyName("page")] public string Page { get; set; } = string.Empty;
}

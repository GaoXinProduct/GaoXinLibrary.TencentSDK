using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public sealed class GetWorkbenchTemplateResponse : WecomBaseResponse
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("image")] public WorkbenchTemplateImage? Image { get; set; }
    [JsonPropertyName("keydata")] public WorkbenchTemplateKeyData? KeyData { get; set; }
    [JsonPropertyName("replace_text")] public WorkbenchReplaceText? ReplaceText { get; set; }
    [JsonPropertyName("webview")] public WorkbenchTemplateWebview? Webview { get; set; }

    public WorkbenchTemplateInfo ToTemplateInfo() => new()
    {
        Type = Type,
        Image = Image,
        KeyData = KeyData,
        ReplaceText = ReplaceText,
        Webview = Webview
    };
}

public sealed class WorkbenchTemplateImage
{
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

public sealed class WorkbenchTemplateKeyData
{
    [JsonPropertyName("items")] public WorkbenchKeyDataItem[]? Items { get; set; }
}

public sealed class WorkbenchTemplateWebview
{
    [JsonPropertyName("url")] public string? Url { get; set; }
}

public sealed class WorkbenchReplaceText
{
    [JsonPropertyName("mobile_webapp_type")] public string? MobileWebAppType { get; set; }
    [JsonPropertyName("web_type")] public string? WebType { get; set; }
    [JsonPropertyName("news_url")] public string? NewsUrl { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}

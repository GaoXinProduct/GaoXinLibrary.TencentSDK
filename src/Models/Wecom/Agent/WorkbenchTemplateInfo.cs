using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public sealed class WorkbenchTemplateInfo
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("image")] public WorkbenchTemplateImage? Image { get; set; }
    [JsonPropertyName("keydata")] public WorkbenchTemplateKeyData? KeyData { get; set; }
    [JsonPropertyName("replace_text")] public WorkbenchReplaceText? ReplaceText { get; set; }
    [JsonPropertyName("webview")] public WorkbenchTemplateWebview? Webview { get; set; }
}

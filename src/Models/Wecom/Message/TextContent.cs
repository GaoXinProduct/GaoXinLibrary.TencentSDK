using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public sealed class TextContent
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}


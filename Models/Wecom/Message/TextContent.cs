using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public class TextContent
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}


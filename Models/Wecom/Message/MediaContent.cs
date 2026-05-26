using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public sealed class MediaContent
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public class MediaContent
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
}


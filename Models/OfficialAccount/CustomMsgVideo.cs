using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>视频消息内容</summary>
public class CustomMsgVideo
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
    [JsonPropertyName("thumb_media_id")] public required string ThumbMediaId { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}


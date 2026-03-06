using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>音乐消息内容</summary>
public class CustomMsgMusic
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("musicurl")] public required string MusicUrl { get; set; }
    [JsonPropertyName("hqmusicurl")] public required string HqMusicUrl { get; set; }
    [JsonPropertyName("thumb_media_id")] public required string ThumbMediaId { get; set; }
}


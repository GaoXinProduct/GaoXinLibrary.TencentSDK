using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>群发图片列表</summary>
public class MassImages
{
    [JsonPropertyName("media_ids")] public required List<string> MediaIds { get; set; }
    [JsonPropertyName("recommend")] public string? Recommend { get; set; }
    [JsonPropertyName("need_open_comment")] public int NeedOpenComment { get; set; }
    [JsonPropertyName("only_fans_can_comment")] public int OnlyFansCanComment { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>评论回复</summary>
public class CommentReply
{
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }
}


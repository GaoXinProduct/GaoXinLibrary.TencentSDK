using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>草稿文章</summary>
public class DraftArticle
{
    /// <summary>标题</summary>
    [JsonPropertyName("title")] public required string Title { get; set; }

    /// <summary>作者</summary>
    [JsonPropertyName("author")] public string? Author { get; set; }

    /// <summary>图文消息的摘要</summary>
    [JsonPropertyName("digest")] public string? Digest { get; set; }

    /// <summary>图文消息的具体内容</summary>
    [JsonPropertyName("content")] public required string Content { get; set; }

    /// <summary>图文消息的原文地址</summary>
    [JsonPropertyName("content_source_url")] public string? ContentSourceUrl { get; set; }

    /// <summary>图文消息的封面图片素材 id</summary>
    [JsonPropertyName("thumb_media_id")] public required string ThumbMediaId { get; set; }

    /// <summary>是否显示封面（1 显示，0 不显示）</summary>
    [JsonPropertyName("show_cover_pic")] public int ShowCoverPic { get; set; }

    /// <summary>是否打开评论（0 不打开，1 打开）</summary>
    [JsonPropertyName("need_open_comment")] public int NeedOpenComment { get; set; }

    /// <summary>是否粉丝才可评论（0 所有人，1 粉丝）</summary>
    [JsonPropertyName("only_fans_can_comment")] public int OnlyFansCanComment { get; set; }
}


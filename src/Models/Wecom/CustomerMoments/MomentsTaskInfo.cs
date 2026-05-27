using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

/// <summary>
/// 朋友圈任务信息
/// </summary>
public record MomentsTaskInfo
{
    /// <summary>朋友圈id</summary>
    [JsonPropertyName("moment_id")]
    public string? MomentId { get; set; }

    /// <summary>朋友圈创建者userid</summary>
    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    /// <summary>创建时间</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    /// <summary>朋友圈创建来源：0-企业 1-个人</summary>
    [JsonPropertyName("create_type")]
    public int CreateType { get; set; }

    /// <summary>可见范围类型：0-部分可见 1-公开</summary>
    [JsonPropertyName("visible_type")]
    public int VisibleType { get; set; }

    /// <summary>文本内容</summary>
    [JsonPropertyName("text")]
    public MomentsTextContent? Text { get; set; }

    /// <summary>图片列表</summary>
    [JsonPropertyName("image")]
    public MomentsImageInfo[]? Image { get; set; }

    /// <summary>视频内容</summary>
    [JsonPropertyName("video")]
    public MomentsVideoInfo? Video { get; set; }

    /// <summary>链接内容</summary>
    [JsonPropertyName("link")]
    public MomentsLinkInfo? Link { get; set; }

    /// <summary>地理位置</summary>
    [JsonPropertyName("location")]
    public MomentsLocationInfo? Location { get; set; }
}

/// <summary>
/// 图片信息
/// </summary>
public record MomentsImageInfo
{
    /// <summary>图片素材id</summary>
    [JsonPropertyName("media_id")]
    public string? MediaId { get; set; }
}

/// <summary>
/// 视频信息
/// </summary>
public record MomentsVideoInfo
{
    /// <summary>视频素材id</summary>
    [JsonPropertyName("media_id")]
    public string? MediaId { get; set; }

    /// <summary>视频封面素材id</summary>
    [JsonPropertyName("thumb_media_id")]
    public string? ThumbMediaId { get; set; }
}

/// <summary>
/// 链接信息
/// </summary>
public record MomentsLinkInfo
{
    /// <summary>网页链接标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>网页链接url</summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

/// <summary>
/// 地理位置信息
/// </summary>
public record MomentsLocationInfo
{
    /// <summary>纬度</summary>
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    /// <summary>经度</summary>
    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    /// <summary>地理位置名称</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
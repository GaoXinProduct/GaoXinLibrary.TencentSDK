using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

/// <summary>
/// 创建客户朋友圈任务请求
/// </summary>
public record CreateMomentsTaskRequest
{
    /// <summary>文本消息内容</summary>
    [JsonPropertyName("text")]
    public MomentsTextContent? Text { get; set; }

    /// <summary>附件列表</summary>
    [JsonPropertyName("attachments")]
    public MomentsAttachment[]? Attachments { get; set; }

    /// <summary>可见范围</summary>
    [JsonPropertyName("visible_range")]
    public VisibleRange? VisibleRange { get; set; }
}

/// <summary>
/// 朋友圈可见范围
/// </summary>
public record VisibleRange
{
    /// <summary>发送者列表</summary>
    [JsonPropertyName("sender_list")]
    public SenderList? SenderList { get; set; }

    /// <summary>客户列表</summary>
    [JsonPropertyName("external_contact_list")]
    public ExternalContactList? ExternalContactList { get; set; }
}

/// <summary>
/// 发送者列表
/// </summary>
public record SenderList
{
    /// <summary>执行者用户列表</summary>
    [JsonPropertyName("user_list")]
    public string[]? UserList { get; set; }

    /// <summary>执行者部门列表</summary>
    [JsonPropertyName("department_list")]
    public int[]? DepartmentList { get; set; }
}

/// <summary>
/// 客户列表
/// </summary>
public record ExternalContactList
{
    /// <summary>客户标签列表</summary>
    [JsonPropertyName("tag_list")]
    public string[]? TagList { get; set; }
}

/// <summary>
/// 朋友圈附件
/// </summary>
public record MomentsAttachment
{
    /// <summary>附件类型</summary>
    [JsonPropertyName("msgtype")]
    public string MsgType { get; set; } = string.Empty;

    /// <summary>图片附件</summary>
    [JsonPropertyName("image")]
    public MomentsImageContent? Image { get; set; }

    /// <summary>视频附件</summary>
    [JsonPropertyName("video")]
    public MomentsVideoContent? Video { get; set; }

    /// <summary>链接附件</summary>
    [JsonPropertyName("link")]
    public MomentsLinkContent? Link { get; set; }
}

/// <summary>
/// 朋友圈文本内容
/// </summary>
public record MomentsTextContent
{
    /// <summary>文本内容</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

/// <summary>
/// 朋友圈图片内容
/// </summary>
public record MomentsImageContent
{
    /// <summary>图片素材id</summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
}

/// <summary>
/// 朋友圈视频内容
/// </summary>
public record MomentsVideoContent
{
    /// <summary>视频素材id</summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
}

/// <summary>
/// 朋友圈链接内容
/// </summary>
public record MomentsLinkContent
{
    /// <summary>链接标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>链接URL</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>封面图片素材id</summary>
    [JsonPropertyName("media_id")]
    public string? MediaId { get; set; }
}
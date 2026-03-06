using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>链接消息内容</summary>
public class KfMsgLink
{
    /// <summary>标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>描述</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }

    /// <summary>链接 URL</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>缩略图链接</summary>
    [JsonPropertyName("pic_url")] public string? PicUrl { get; set; }
}


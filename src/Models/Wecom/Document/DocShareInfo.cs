using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>文档分享信息</summary>
public class DocShareInfo
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string? DocId { get; set; }

    /// <summary>分享链接</summary>
    [JsonPropertyName("share_url")] public string? ShareUrl { get; set; }

    /// <summary>分享类型：0-关闭分享，1-仅可查看，2-可编辑</summary>
    [JsonPropertyName("share_mode")] public int ShareMode { get; set; }

    /// <summary>有效期到期时间</summary>
    [JsonPropertyName("expired_time")] public long ExpiredTime { get; set; }

    /// <summary>可见范围</summary>
    [JsonPropertyName("visible_range")] public string? VisibleRange { get; set; }
}

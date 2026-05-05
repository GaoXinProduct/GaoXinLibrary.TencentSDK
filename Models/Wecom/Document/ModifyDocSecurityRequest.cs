using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>修改文档安全设置请求</summary>
public class ModifyDocSecurityRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>安全类型：0-关闭，1-仅可查看，2-可编辑</summary>
    [JsonPropertyName("security_type")]
    public int SecurityType { get; set; }

    /// <summary>链接有效期（Unix时间戳）</summary>
    [JsonPropertyName("expired_time")]
    public long ExpiredTime { get; set; }
}

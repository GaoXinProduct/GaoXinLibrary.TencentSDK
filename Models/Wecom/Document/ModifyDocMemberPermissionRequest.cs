using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>修改文档成员权限请求</summary>
public class ModifyDocMemberPermissionRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>成员 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>权限类型：1-可编辑，2-可查看</summary>
    [JsonPropertyName("permission")]
    public int Permission { get; set; }

    /// <summary>权限过期时间（Unix时间戳，0表示不过期）</summary>
    [JsonPropertyName("expired_time")]
    public long ExpiredTime { get; set; }
}

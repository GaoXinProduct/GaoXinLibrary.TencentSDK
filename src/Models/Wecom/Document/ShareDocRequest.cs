
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>分享文档请求</summary>
public sealed class ShareDocRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>旧版成员列表。通过文档成员接口设置文档权限。</summary>
    [Obsolete("请使用 ModifyDocMembersAsync 设置文档成员权限。")]
    [JsonIgnore]
    public string[] UserIdList { get; set; } = [];
}

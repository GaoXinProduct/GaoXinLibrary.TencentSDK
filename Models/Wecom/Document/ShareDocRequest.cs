using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>分享文档请求</summary>
public class ShareDocRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>分享给的用户 userid 列表</summary>
    [JsonPropertyName("userid_list")]
    public string[] UserIdList { get; set; } = [];
}

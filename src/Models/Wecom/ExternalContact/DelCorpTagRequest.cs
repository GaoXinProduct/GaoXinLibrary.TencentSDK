
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>删除企业客户标签请求</summary>
public sealed class DelCorpTagRequest
{
    [JsonPropertyName("tag_id")] public string[]? TagId { get; set; }
    [JsonPropertyName("group_id")] public string[]? GroupId { get; set; }
}

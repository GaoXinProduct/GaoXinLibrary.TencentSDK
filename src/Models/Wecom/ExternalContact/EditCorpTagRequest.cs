
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>编辑企业客户标签请求</summary>
public sealed class EditCorpTagRequest
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("order")] public int? Order { get; set; }
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>编辑客户企业标签请求</summary>
public sealed class MarkTagRequest
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
    [JsonPropertyName("add_tag")] public string[]? AddTag { get; set; }
    [JsonPropertyName("remove_tag")] public string[]? RemoveTag { get; set; }
}

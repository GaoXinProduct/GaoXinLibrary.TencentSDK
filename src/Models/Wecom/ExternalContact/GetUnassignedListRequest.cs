namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取待分配的离职成员列表请求</summary>
public sealed class GetUnassignedListRequest
{
    [JsonPropertyName("page_id")] public int PageId { get; set; }
    [JsonPropertyName("page_size")] public int PageSize { get; set; } = 1000;
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
}

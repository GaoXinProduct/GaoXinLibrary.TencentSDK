namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取获客链接添加的客户群信息请求</summary>
public sealed class GetAcquisitionChatInfoRequest
{
    [JsonPropertyName("link_id")] public string LinkId { get; set; } = string.Empty;
    [JsonPropertyName("memberid")] public string? MemberId { get; set; }
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; } = 100;
}

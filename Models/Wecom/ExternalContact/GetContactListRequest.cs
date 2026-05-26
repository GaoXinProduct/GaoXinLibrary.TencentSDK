namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取已服务的外部联系人请求</summary>
public sealed class GetContactListRequest
{
    [JsonPropertyName("start_time")] public long StartTime { get; set; }
    [JsonPropertyName("end_time")] public long EndTime { get; set; }
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; } = 1000;
}

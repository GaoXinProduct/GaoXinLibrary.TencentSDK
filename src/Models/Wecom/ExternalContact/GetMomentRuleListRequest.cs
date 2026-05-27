namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取朋友圈规则组请求</summary>
public sealed class GetMomentRuleListRequest
{
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; } = 1000;
}

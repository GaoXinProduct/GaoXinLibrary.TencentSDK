namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>删除联系我方式请求</summary>
public sealed class DelContactWayRequest
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
}

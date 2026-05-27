namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取联系我方式请求</summary>
public sealed class GetContactWayRequest
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
}

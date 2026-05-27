namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取进群方式请求</summary>
public sealed class GetJoinWayRequest
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
}

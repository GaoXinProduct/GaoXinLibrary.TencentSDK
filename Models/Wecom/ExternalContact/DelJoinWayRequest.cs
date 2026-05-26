namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>删除进群方式请求</summary>
public sealed class DelJoinWayRequest
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
}

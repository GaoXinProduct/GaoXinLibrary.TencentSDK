using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>配置进群方式响应</summary>
public sealed class AddJoinWayResponse : WecomBaseResponse
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
}

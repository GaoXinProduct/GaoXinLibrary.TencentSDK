using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>事件消息内容</summary>
public class KfMsgEvent
{
    /// <summary>事件类型</summary>
    [JsonPropertyName("event_type")] public string? EventType { get; set; }

    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string? OpenKfId { get; set; }

    /// <summary>微信客户 external_userid</summary>
    [JsonPropertyName("external_userid")] public string? ExternalUserId { get; set; }

    /// <summary>接待人员变更场景值</summary>
    [JsonPropertyName("scene")] public string? Scene { get; set; }

    /// <summary>接待人员 userid</summary>
    [JsonPropertyName("servicer_userid")] public string? ServicerUserId { get; set; }

    /// <summary>变更类型</summary>
    [JsonPropertyName("change_type")] public int? ChangeType { get; set; }

    /// <summary>新的会话状态</summary>
    [JsonPropertyName("new_service_state")] public int? NewServiceState { get; set; }

    /// <summary>旧的会话状态</summary>
    [JsonPropertyName("old_service_state")] public int? OldServiceState { get; set; }
}


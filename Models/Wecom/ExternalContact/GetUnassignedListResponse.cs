using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>待分配列表响应</summary>
public sealed class GetUnassignedListResponse : WecomBaseResponse
{
    [JsonPropertyName("info")] public UnassignedInfo[]? Info { get; set; }
    [JsonPropertyName("is_last")] public bool IsLast { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

public sealed class UnassignedInfo
{
    [JsonPropertyName("handover_userid")] public string HandoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
    [JsonPropertyName("dimission_time")] public long DimissionTime { get; set; }
}

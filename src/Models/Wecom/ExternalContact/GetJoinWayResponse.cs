using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取进群方式响应</summary>
public sealed class GetJoinWayResponse : WecomBaseResponse
{
    [JsonPropertyName("join_way")] public JoinWayInfo? JoinWay { get; set; }
}

public sealed class JoinWayInfo
{
    [JsonPropertyName("config_id")] public string ConfigId { get; set; } = string.Empty;
    [JsonPropertyName("scene")] public int Scene { get; set; }
    [JsonPropertyName("remark")] public string? Remark { get; set; }
    [JsonPropertyName("auto_create_room")] public int AutoCreateRoom { get; set; }
    [JsonPropertyName("room_base_name")] public string? RoomBaseName { get; set; }
    [JsonPropertyName("room_base_id")] public int RoomBaseId { get; set; }
    [JsonPropertyName("chat_id_list")] public string[]? ChatIdList { get; set; }
    [JsonPropertyName("state")] public string? State { get; set; }
    [JsonPropertyName("qr_code")] public string? QrCode { get; set; }
}

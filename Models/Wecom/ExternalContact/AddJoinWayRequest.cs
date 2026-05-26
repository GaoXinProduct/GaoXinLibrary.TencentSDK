namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>配置客户群进群方式请求</summary>
public sealed class AddJoinWayRequest
{
    [JsonPropertyName("scene")] public int Scene { get; set; }
    [JsonPropertyName("remark")] public string? Remark { get; set; }
    [JsonPropertyName("auto_create_room")] public int AutoCreateRoom { get; set; }
    [JsonPropertyName("room_base_name")] public string? RoomBaseName { get; set; }
    [JsonPropertyName("room_base_id")] public int RoomBaseId { get; set; }
    [JsonPropertyName("chat_id_list")] public string[]? ChatIdList { get; set; }
    [JsonPropertyName("state")] public string? State { get; set; }
}

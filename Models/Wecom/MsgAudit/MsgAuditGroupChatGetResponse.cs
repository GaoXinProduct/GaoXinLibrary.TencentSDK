using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>获取会话内容存档内部群信息响应</summary>
public class MsgAuditGroupChatGetResponse : WecomBaseResponse
{
    /// <summary>群成员列表</summary>
    [JsonPropertyName("roomname")] public string? RoomName { get; set; }

    /// <summary>群创建者的 userid</summary>
    [JsonPropertyName("creator")] public string? Creator { get; set; }

    /// <summary>群创建时间（时间戳）</summary>
    [JsonPropertyName("room_create_time")] public long RoomCreateTime { get; set; }

    /// <summary>群公告</summary>
    [JsonPropertyName("notice")] public string? Notice { get; set; }

    /// <summary>群成员列表</summary>
    [JsonPropertyName("members")] public MsgAuditGroupMember[]? Members { get; set; }
}


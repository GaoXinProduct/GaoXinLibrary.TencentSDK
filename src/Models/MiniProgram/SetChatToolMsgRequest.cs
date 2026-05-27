using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 修改小程序聊天工具的动态卡片消息请求（POST /cgi-bin/message/wxopen/updatablemsg/setchat）
/// </summary>
public sealed class SetChatToolMsgRequest
{
    /// <summary>动态消息的activity_id</summary>
    [JsonPropertyName("activity_id")] public required string ActivityId { get; set; }
    /// <summary>消息状态（0未开始 1进行中 2已完结）</summary>
    [JsonPropertyName("target_state")] public required int TargetState { get; set; }
    /// <summary>聊天信息</summary>
    [JsonPropertyName("chat")] public ChatInfo? Chat { get; set; }
}

public sealed class ChatInfo
{
    /// <summary>内容</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }
    /// <summary>更新时间</summary>
    [JsonPropertyName("update_time")] public long UpdateTime { get; set; }
}
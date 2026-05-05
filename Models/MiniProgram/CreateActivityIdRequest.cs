using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建activity_id请求（POST /cgi-bin/message/wxopen/activityid/create）
/// </summary>
public sealed class CreateActivityIdRequest
{
    /// <summary>转发游戏时带的参数</summary>
    [JsonPropertyName("action_info")] public ActionInfo? ActionInfo { get; set; }
}

public sealed class ActionInfo
{
    /// <summary>透传到动态消息的参数</summary>
    [JsonPropertyName("message_graph")] public MessageGraph? MessageGraph { get; set; }
}

public sealed class MessageGraph
{
    /// <summary>透传数据</summary>
    [JsonPropertyName("data")] public string? Data { get; set; }
}
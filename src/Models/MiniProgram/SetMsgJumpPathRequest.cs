using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 消息跳转路径设置请求（POST /wxa/sec/order/set_msg_jump_path）
/// </summary>
public sealed class SetMsgJumpPathRequest
{
    /// <summary>跳转路径</summary>
    [JsonPropertyName("path")] public required string Path { get; set; }
}
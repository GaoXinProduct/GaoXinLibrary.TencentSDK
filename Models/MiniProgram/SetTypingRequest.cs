using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 下发客服当前输入状态请求（POST /cgi-bin/message/custom/typing）
/// </summary>
public class SetTypingRequest
{
    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("touser")] public required string ToUser { get; set; }
    /// <summary>命令（Typing / CancelTyping）</summary>
    [JsonPropertyName("command")] public required string Command { get; set; }
}


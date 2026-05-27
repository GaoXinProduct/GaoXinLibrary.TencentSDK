using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>输入状态请求（POST /cgi-bin/message/custom/typing）</summary>
public sealed class OfficialSetTypingRequest
{
    [JsonPropertyName("touser")] public required string ToUser { get; set; }
    /// <summary>Typing 或 CancelTyping</summary>
    [JsonPropertyName("command")] public required string Command { get; set; }
}


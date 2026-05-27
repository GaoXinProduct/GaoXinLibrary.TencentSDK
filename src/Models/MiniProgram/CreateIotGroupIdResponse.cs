using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建设备组响应
/// </summary>
public sealed class CreateIotGroupIdResponse : WechatBaseResponse
{
    /// <summary>设备组ID</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 设备组添加设备响应
/// </summary>
public sealed class AddIotGroupDeviceResponse : WechatBaseResponse
{
    /// <summary>成功添加的设备数量</summary>
    [JsonPropertyName("success_count")] public int SuccessCount { get; init; }
    /// <summary>失败的设备数量</summary>
    [JsonPropertyName("fail_count")] public int FailCount { get; init; }
}
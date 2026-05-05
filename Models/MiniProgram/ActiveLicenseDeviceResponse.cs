using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 激活设备license响应
/// </summary>
public sealed class ActiveLicenseDeviceResponse : WechatBaseResponse
{
    /// <summary>激活状态</summary>
    [JsonPropertyName("active")] public bool Active { get; init; }
}
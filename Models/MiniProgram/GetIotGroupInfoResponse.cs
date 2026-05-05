using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询设备组信息响应
/// </summary>
public sealed class GetIotGroupInfoResponse : WechatBaseResponse
{
    /// <summary>设备组名称</summary>
    [JsonPropertyName("group_name")] public string? GroupName { get; init; }
    /// <summary>设备数量</summary>
    [JsonPropertyName("device_count")] public int DeviceCount { get; init; }
    /// <summary>设备列表</summary>
    [JsonPropertyName("devices")] public List<DeviceInfo>? Devices { get; init; }
}

/// <summary>
/// 设备信息
/// </summary>
public sealed class DeviceInfo
{
    /// <summary>设备ID</summary>
    [JsonPropertyName("device_id")] public string? DeviceId { get; init; }
    /// <summary>设备序列号</summary>
    [JsonPropertyName("sn")] public string? Sn { get; init; }
    /// <summary>状态</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
}
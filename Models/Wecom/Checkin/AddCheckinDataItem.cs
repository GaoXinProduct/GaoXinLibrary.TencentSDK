using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>添加打卡记录项</summary>
public class AddCheckinDataItem
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>打卡时间（Unix 时间戳）</summary>
    [JsonPropertyName("checkin_time")] public long CheckinTime { get; set; }

    /// <summary>设备序列号</summary>
    [JsonPropertyName("device_sn")] public string? DeviceSn { get; set; }

    /// <summary>设备名称</summary>
    [JsonPropertyName("device_name")] public string? DeviceName { get; set; }
}


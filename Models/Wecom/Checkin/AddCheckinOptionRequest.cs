using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>添加打卡规则请求</summary>
public class AddCheckinOptionRequest
{
    /// <summary>打卡规则</summary>
    [JsonPropertyName("group")] public CheckinGroup Group { get; set; } = new();
}


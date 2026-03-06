using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>添加打卡记录请求</summary>
public class AddCheckinDataRequest
{
    /// <summary>打卡记录列表</summary>
    [JsonPropertyName("checkindata")] public AddCheckinDataItem[] CheckinData { get; set; } = [];
}


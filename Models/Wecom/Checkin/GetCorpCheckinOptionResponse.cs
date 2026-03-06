using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取企业所有打卡规则响应</summary>
public class GetCorpCheckinOptionResponse : WecomBaseResponse
{
    /// <summary>企业规则信息列表</summary>
    [JsonPropertyName("group")] public CheckinGroup[]? Group { get; set; }
}


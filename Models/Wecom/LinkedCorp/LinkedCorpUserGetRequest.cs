using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取互联企业成员详细信息请求</summary>
public class LinkedCorpUserGetRequest
{
    /// <summary>该字段填写 CorpId/UserId，如 CORPID/USERID</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
}


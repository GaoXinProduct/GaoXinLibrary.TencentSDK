using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取会话同意情况请求</summary>
public class CheckAgreeRequest
{
    /// <summary>待查询的会话信息列表</summary>
    [JsonPropertyName("info")] public CheckAgreeItem[] Info { get; set; } = [];
}


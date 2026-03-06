using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取会话内容存档开启成员列表请求</summary>
public class GetPermitUserListRequest
{
    /// <summary>企业内开启会话内容存档的成员类型（非必填）：0-全部 1-仅内部 2-仅外部</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }
}


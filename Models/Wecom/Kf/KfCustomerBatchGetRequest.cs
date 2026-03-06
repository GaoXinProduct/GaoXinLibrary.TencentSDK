using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>批量获取客户基础信息请求</summary>
public class KfCustomerBatchGetRequest
{
    /// <summary>微信客户的 external_userid 列表，最多100个</summary>
    [JsonPropertyName("external_userid_list")] public string[] ExternalUserIdList { get; set; } = [];

    /// <summary>是否需要返回 unionid，0-不需要 1-需要</summary>
    [JsonPropertyName("need_enter_session_context")] public int? NeedEnterSessionContext { get; set; }
}


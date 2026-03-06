using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>同意信息</summary>
public class AgreeInfo
{
    /// <summary>内部成员的 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>外部成员的 externalopenid</summary>
    [JsonPropertyName("exteranalopenid")] public string? ExternalOpenId { get; set; }

    /// <summary>同意状态：Agree-同意 Disagree-不同意 Default_Agree-默认同意</summary>
    [JsonPropertyName("agree_status")] public string? AgreeStatus { get; set; }

    /// <summary>同意状态改变的具体时间（时间戳）</summary>
    [JsonPropertyName("status_change_time")] public long StatusChangeTime { get; set; }
}


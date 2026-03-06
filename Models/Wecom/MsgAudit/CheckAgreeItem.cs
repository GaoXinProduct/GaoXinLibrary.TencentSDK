using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>待查询的会话信息</summary>
public class CheckAgreeItem
{
    /// <summary>内部成员的 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>外部成员的 externalopenid</summary>
    [JsonPropertyName("exteranalopenid")] public string ExternalOpenId { get; set; } = string.Empty;
}


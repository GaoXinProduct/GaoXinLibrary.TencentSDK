using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>群成员信息</summary>
public class MsgAuditGroupMember
{
    /// <summary>成员 userid</summary>
    [JsonPropertyName("memberid")] public string? MemberId { get; set; }

    /// <summary>加入群聊的时间（时间戳）</summary>
    [JsonPropertyName("jointime")] public long JoinTime { get; set; }
}


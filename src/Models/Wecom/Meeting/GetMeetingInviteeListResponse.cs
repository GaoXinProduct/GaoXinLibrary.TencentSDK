using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议受邀成员列表响应</summary>
/// <remarks>doc path: /98160</remarks>
public class GetMeetingInviteeListResponse : WecomBaseResponse
{
    /// <summary>受邀成员列表</summary>
    [JsonPropertyName("invitee_list")]
    public List<MeetingInviteeInfo>? InviteeList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>受邀成员信息</summary>
public class MeetingInviteeInfo
{
    /// <summary>成员类型：1-企业用户，2-外部用户</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>成员userid（企业用户）</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>外部成员名称（外部用户）</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>手机号</summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>邮箱</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>加入状态：0-未加入，1-已加入</summary>
    [JsonPropertyName("join_status")]
    public int JoinStatus { get; set; }
}
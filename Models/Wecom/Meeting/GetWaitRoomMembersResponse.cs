using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取等候室成员记录响应</summary>
/// <remarks>doc path: /98164</remarks>
public class GetWaitRoomMembersResponse : WecomBaseResponse
{
    /// <summary>等候室成员列表</summary>
    [JsonPropertyName("wait_room_members")]
    public List<WaitRoomMemberInfo>? WaitRoomMembers { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>等候室成员信息</summary>
public class WaitRoomMemberInfo
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>用户名</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>成员类型：0-内部成员，1-外部成员，2-PSTN用户，3-匿名用户</summary>
    [JsonPropertyName("member_type")]
    public int MemberType { get; set; }

    /// <summary>进入等候室时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("enter_wait_room_time")]
    public long EnterWaitRoomTime { get; set; }

    /// <summary>设备类型：0-未知，1-Windows，2-macOS，3-iOS，4-Android，5-小程序，6-企业微信内置，7-H5</summary>
    [JsonPropertyName("device_type")]
    public int DeviceType { get; set; }
}
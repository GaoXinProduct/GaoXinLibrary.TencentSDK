using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会嘉宾列表响应</summary>
/// <remarks>doc path: /98871</remarks>
public class GetWebinarGuestListResponse : WecomBaseResponse
{
    /// <summary>嘉宾列表</summary>
    [JsonPropertyName("guest_list")]
    public List<WebinarGuestInfo>? GuestList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>网络研讨会嘉宾信息</summary>
public class WebinarGuestInfo
{
    /// <summary>嘉宾userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>嘉宾名称</summary>
    [JsonPropertyName("guest_name")]
    public string? GuestName { get; set; }

    /// <summary>加入状态：0-未加入，1-已加入</summary>
    [JsonPropertyName("join_status")]
    public int JoinStatus { get; set; }
}
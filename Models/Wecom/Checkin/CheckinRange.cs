using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>打卡人员范围</summary>
public class CheckinRange
{
    /// <summary>部门 id 列表</summary>
    [JsonPropertyName("party_id")] public int[]? PartyId { get; set; }

    /// <summary>成员 userid 列表</summary>
    [JsonPropertyName("userid")] public string[]? UserId { get; set; }

    /// <summary>标签 id 列表</summary>
    [JsonPropertyName("tagid")] public int[]? TagId { get; set; }
}


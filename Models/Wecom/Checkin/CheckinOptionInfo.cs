using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>员工打卡规则信息</summary>
public class CheckinOptionInfo
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>规则信息</summary>
    [JsonPropertyName("group")] public CheckinGroup? Group { get; set; }
}


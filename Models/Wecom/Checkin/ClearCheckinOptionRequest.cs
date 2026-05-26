using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>清空打卡规则请求</summary>
public sealed class ClearCheckinOptionRequest
{
    /// <summary>打卡规则 id</summary>
    [JsonPropertyName("groupid")] public int GroupId { get; set; }
}


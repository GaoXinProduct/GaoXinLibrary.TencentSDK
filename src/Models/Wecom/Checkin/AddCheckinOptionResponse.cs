using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>添加打卡规则响应</summary>
public sealed class AddCheckinOptionResponse : WecomBaseResponse
{
    /// <summary>新增打卡规则 id</summary>
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}


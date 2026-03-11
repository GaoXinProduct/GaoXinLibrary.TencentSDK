using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取成员直播ID列表响应</summary>
public class GetUserLivingIdResponse : WecomBaseResponse
{
    /// <summary>直播ID列表</summary>
    [JsonPropertyName("livingid_list")] public string[]? LivingIdList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

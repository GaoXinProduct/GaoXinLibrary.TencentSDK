using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

/// <summary>获取高级功能账号列表响应</summary>
public class GetAdvancedAccountListResponse : WecomBaseResponse
{
    /// <summary>账号列表</summary>
    [JsonPropertyName("account_list")] public AdvancedAccountInfo[]? AccountList { get; set; }

    /// <summary>是否还有更多</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

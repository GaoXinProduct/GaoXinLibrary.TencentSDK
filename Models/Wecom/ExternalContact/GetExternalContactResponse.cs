using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取客户详情响应</summary>
public class GetExternalContactResponse : WecomBaseResponse
{
    /// <summary>外部联系人信息</summary>
    [JsonPropertyName("external_contact")] public ExternalContactInfo? ExternalContact { get; set; }

    /// <summary>跟进人信息列表</summary>
    [JsonPropertyName("follow_user")] public FollowUser[]? FollowUser { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

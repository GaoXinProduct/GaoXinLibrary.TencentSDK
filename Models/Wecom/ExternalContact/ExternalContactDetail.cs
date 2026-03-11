using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>客户详情</summary>
public class ExternalContactDetail
{
    /// <summary>外部联系人信息</summary>
    [JsonPropertyName("external_contact")] public ExternalContactInfo? ExternalContact { get; set; }

    /// <summary>跟进人信息</summary>
    [JsonPropertyName("follow_info")] public FollowUser? FollowInfo { get; set; }
}

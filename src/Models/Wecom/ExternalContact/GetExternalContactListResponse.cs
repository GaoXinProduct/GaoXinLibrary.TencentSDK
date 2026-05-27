using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取客户列表响应</summary>
public sealed class GetExternalContactListResponse : WecomBaseResponse
{
    /// <summary>外部联系人external_userid列表</summary>
    [JsonPropertyName("external_userid")] public string[]? ExternalUserIdList { get; set; }
}

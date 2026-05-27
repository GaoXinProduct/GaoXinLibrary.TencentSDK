using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>分配离职成员的客户响应</summary>
public sealed class ResignedTransferCustomerResponse : WecomBaseResponse
{
    [JsonPropertyName("customer")] public ResignedTransferCustomerItem[]? Customer { get; set; }
}

/// <summary>离职客户分配结果项</summary>
public sealed class ResignedTransferCustomerItem
{
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
    [JsonPropertyName("errcode")] public int ErrCode { get; set; }
}

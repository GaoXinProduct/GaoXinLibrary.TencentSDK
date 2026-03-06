using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>批量获取客户基础信息响应</summary>
public class KfCustomerBatchGetResponse : WecomBaseResponse
{
    /// <summary>客户列表</summary>
    [JsonPropertyName("customer_list")] public KfCustomer[]? CustomerList { get; set; }
}


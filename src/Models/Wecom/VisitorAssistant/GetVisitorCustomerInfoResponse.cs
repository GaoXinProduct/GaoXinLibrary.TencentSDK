using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public class GetVisitorCustomerInfoResponse : WecomBaseResponse
{
    [JsonPropertyName("customer_list")]
    public VisitorCustomerInfo[]? CustomerList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}
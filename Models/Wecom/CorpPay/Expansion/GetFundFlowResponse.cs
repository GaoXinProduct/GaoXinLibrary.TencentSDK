using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetFundFlowResponse : WecomBaseResponse
{
    [JsonPropertyName("fund_flow_list")]
    public FundFlowItem[]? FundFlowList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class FundFlowItem
{
    [JsonPropertyName("flow_id")]
    public string? FlowId { get; set; }

    [JsonPropertyName("flow_type")]
    public string? FlowType { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public class GetVisitorQuotaResponse : WecomBaseResponse
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("balance")]
    public int Balance { get; set; }

    [JsonPropertyName("quota_list")]
    public QuotaInfo[]? QuotaList { get; set; }
}

public class QuotaInfo
{
    [JsonPropertyName("expire_date")]
    public long ExpireDate { get; set; }

    [JsonPropertyName("balance")]
    public int Balance { get; set; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class SendRedpackResponse : WecomBaseResponse
{
    [JsonPropertyName("redpack_id")]
    public string? RedpackId { get; set; }
}
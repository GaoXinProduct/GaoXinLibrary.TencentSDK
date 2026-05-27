using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.AppInvoke;

public class SyncInvokeResponse : WecomBaseResponse
{
    [JsonPropertyName("invoke_result")]
    public object? InvokeResult { get; set; }
}
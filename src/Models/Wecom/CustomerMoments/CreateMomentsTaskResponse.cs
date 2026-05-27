using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

public class CreateMomentsTaskResponse : WecomBaseResponse
{
    [JsonPropertyName("jobid")]
    public string? JobId { get; set; }
}
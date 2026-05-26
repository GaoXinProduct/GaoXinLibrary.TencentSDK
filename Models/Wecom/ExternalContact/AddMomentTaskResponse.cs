using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class AddMomentTaskResponse : WecomBaseResponse
{
    [JsonPropertyName("jobid")]
    public string? JobId { get; set; }
}

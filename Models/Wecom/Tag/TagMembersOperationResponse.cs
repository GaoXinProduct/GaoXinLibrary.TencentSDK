using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

public sealed class TagMembersOperationResponse : WecomBaseResponse
{
    [JsonPropertyName("invalidlist")] public string? InvalidList { get; set; }
    [JsonPropertyName("invalidparty")] public string[]? InvalidParty { get; set; }
}


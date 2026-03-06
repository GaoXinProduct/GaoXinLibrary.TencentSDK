using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

public class TagMembersOperationResponse : WecomBaseResponse
{
    [JsonPropertyName("invalidlist")] public string? InvalidList { get; set; }
    [JsonPropertyName("invalidparty")] public string[]? InvalidParty { get; set; }
}


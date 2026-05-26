using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public sealed class WorkbenchKeyDataItem
{
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;
    [JsonPropertyName("data")] public string Data { get; set; } = string.Empty;
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

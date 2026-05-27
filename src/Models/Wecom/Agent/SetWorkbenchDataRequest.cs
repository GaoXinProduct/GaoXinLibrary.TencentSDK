using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public sealed class SetWorkbenchDataRequest
{
    [JsonPropertyName("agentid")] public int? AgentId { get; set; }
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("type")] public string Type { get; set; } = "keydata";
    [JsonPropertyName("keydata")] public SetWorkbenchDataKeyData KeyData { get; set; } = new();
    [JsonPropertyName("template_id")] public string? TemplateId { get; set; }
}

public sealed class SetWorkbenchDataKeyData
{
    [JsonPropertyName("items")] public WorkbenchDataKeyItem[]? Items { get; set; }
}

public sealed class WorkbenchDataKeyItem
{
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;
    [JsonPropertyName("data")] public string Data { get; set; } = string.Empty;
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

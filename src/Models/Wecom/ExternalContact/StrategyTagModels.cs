using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>查询规则组下的企业客户标签。</summary>
public sealed record GetStrategyTagListRequest
{
    [JsonPropertyName("strategy_id")] public int? StrategyId { get; init; }
    [JsonPropertyName("tag_id")] public string[]? TagIds { get; init; }

    /// <summary>同时提供标签和标签组时，仅按标签组过滤。</summary>
    [JsonPropertyName("group_id")] public string[]? GroupIds { get; init; }
}

/// <summary>包含所属规则组的企业客户标签组。</summary>
public sealed record StrategyTagGroup : CorpTagGroup
{
    [JsonPropertyName("strategy_id")] public int? StrategyId { get; init; }
}

/// <summary>规则组下的企业客户标签列表。</summary>
public sealed class GetStrategyTagListResponse : WecomBaseResponse
{
    [JsonPropertyName("tag_group")] public StrategyTagGroup[]? TagGroup { get; init; }
}

/// <summary>向指定规则组的标签组添加企业客户标签。</summary>
public sealed record AddStrategyTagRequest
{
    [JsonPropertyName("strategy_id")] public required int StrategyId { get; init; }
    [JsonPropertyName("group_id")] public string? GroupId { get; init; }
    [JsonPropertyName("group_name")] public string? GroupName { get; init; }
    [JsonPropertyName("order")] public uint? Order { get; init; }
    [JsonPropertyName("tag")] public required CorpTagAddItem[] Tags { get; init; }
}

/// <summary>添加规则组下的企业客户标签的结果。</summary>
public sealed class AddStrategyTagResponse : WecomBaseResponse
{
    [JsonPropertyName("tag_group")] public CorpTagGroup? TagGroup { get; init; }
}

/// <summary>修改指定规则组内的标签或标签组。</summary>
public sealed record UpdateStrategyTagRequest
{
    [JsonPropertyName("id")] public required string Id { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("order")] public uint? Order { get; init; }
}

/// <summary>删除指定规则组内的标签或标签组。</summary>
public sealed record DeleteStrategyTagRequest
{
    [JsonPropertyName("tag_id")] public string[]? TagIds { get; init; }
    [JsonPropertyName("group_id")] public string[]? GroupIds { get; init; }
}

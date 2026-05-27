using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>添加知识库分组响应</summary>
public sealed class KfKnowledgeAddGroupResponse : WecomBaseResponse
{
    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; set; }
}


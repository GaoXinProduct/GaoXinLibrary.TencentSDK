using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>删除知识库分组请求</summary>
public sealed class KfKnowledgeDelGroupRequest
{
    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string GroupId { get; set; } = string.Empty;
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>删除知识库分组请求</summary>
public class KfKnowledgeDelGroupRequest
{
    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string GroupId { get; set; } = string.Empty;
}


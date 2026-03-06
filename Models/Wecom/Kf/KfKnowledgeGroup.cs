using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>知识库分组信息</summary>
public class KfKnowledgeGroup
{
    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; set; }

    /// <summary>分组名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>是否为默认分组</summary>
    [JsonPropertyName("is_default")] public int IsDefault { get; set; }
}


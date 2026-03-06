using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>修改知识库分组请求</summary>
public class KfKnowledgeModGroupRequest
{
    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string GroupId { get; set; } = string.Empty;

    /// <summary>分组名称</summary>
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
}


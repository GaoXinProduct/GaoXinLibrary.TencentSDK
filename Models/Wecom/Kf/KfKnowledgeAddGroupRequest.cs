using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>添加知识库分组请求</summary>
public class KfKnowledgeAddGroupRequest
{
    /// <summary>分组名称</summary>
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
}


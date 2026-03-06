using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取知识库分组列表请求</summary>
public class KfKnowledgeListGroupRequest
{
    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }

    /// <summary>分页大小，最大100</summary>
    [JsonPropertyName("limit")] public int? Limit { get; set; }

    /// <summary>分组 id 筛选（非必填）</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; set; }
}


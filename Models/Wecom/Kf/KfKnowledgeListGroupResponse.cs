using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取知识库分组列表响应</summary>
public class KfKnowledgeListGroupResponse : WecomBaseResponse
{
    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")] public int HasMore { get; set; }

    /// <summary>下次调用带上该值翻页</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }

    /// <summary>分组列表</summary>
    [JsonPropertyName("group_list")] public KfKnowledgeGroup[]? GroupList { get; set; }
}


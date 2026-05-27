using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取布局模板列表响应</summary>
/// <remarks>doc path: /98844</remarks>
public class GetLayoutTemplateListResponse : WecomBaseResponse
{
    /// <summary>布局模板列表</summary>
    [System.Text.Json.Serialization.JsonPropertyName("layout_template_list")]
    public List<LayoutTemplateInfo>? LayoutTemplateList { get; set; }
}

/// <summary>布局模板信息</summary>
public class LayoutTemplateInfo
{
    /// <summary>布局模板ID</summary>
    [System.Text.Json.Serialization.JsonPropertyName("layout_template_id")]
    public string? LayoutTemplateId { get; set; }

    /// <summary>布局模板名称</summary>
    [System.Text.Json.Serialization.JsonPropertyName("layout_template_name")]
    public string? LayoutTemplateName { get; set; }

    /// <summary>布局模板类型：1-宫格，2-演讲者，3-尊享直播，4-自定义</summary>
    [System.Text.Json.Serialization.JsonPropertyName("layout_template_type")]
    public int LayoutTemplateType { get; set; }

    /// <summary>缩略图URL</summary>
    [System.Text.Json.Serialization.JsonPropertyName("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取用户布局响应</summary>
/// <remarks>doc path: /98865</remarks>
public class GetUserLayoutResponse : WecomBaseResponse
{
    /// <summary>布局模板ID</summary>
    [JsonPropertyName("layout_template_id")]
    public string? LayoutTemplateId { get; set; }

    /// <summary>布局模板名称</summary>
    [JsonPropertyName("layout_template_name")]
    public string? LayoutTemplateName { get; set; }

    /// <summary>布局模板类型：1-宫格，2-演讲者，3-尊享直播，4-自定义</summary>
    [JsonPropertyName("layout_template_type")]
    public int LayoutTemplateType { get; set; }
}
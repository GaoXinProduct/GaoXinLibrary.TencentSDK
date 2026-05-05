using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议布局列表响应</summary>
/// <remarks>doc path: /98862</remarks>
public class GetMeetingLayoutListResponse : WecomBaseResponse
{
    /// <summary>布局列表</summary>
    [JsonPropertyName("layout_list")]
    public List<MeetingLayoutInfo>? LayoutList { get; set; }
}

/// <summary>会议布局信息</summary>
public class MeetingLayoutInfo
{
    /// <summary>布局ID</summary>
    [JsonPropertyName("layout_id")]
    public string? LayoutId { get; set; }

    /// <summary>布局模板ID</summary>
    [JsonPropertyName("layout_template_id")]
    public string? LayoutTemplateId { get; set; }

    /// <summary>布局模板名称</summary>
    [JsonPropertyName("layout_template_name")]
    public string? LayoutTemplateName { get; set; }

    /// <summary>布局模板类型：1-宫格，2-演讲者，3-尊享直播，4-自定义</summary>
    [JsonPropertyName("layout_template_type")]
    public int LayoutTemplateType { get; set; }

    /// <summary>是否为默认布局</summary>
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }
}
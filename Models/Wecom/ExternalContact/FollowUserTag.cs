using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>跟进人标签</summary>
public class FollowUserTag
{
    /// <summary>标签的分组名称</summary>
    [JsonPropertyName("group_name")] public string? GroupName { get; set; }

    /// <summary>标签名称</summary>
    [JsonPropertyName("tag_name")] public string? TagName { get; set; }

    /// <summary>标签类型，1-企业设置，2-用户自定义，3-规则组标签</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>标签id</summary>
    [JsonPropertyName("tag_id")] public string? TagId { get; set; }
}

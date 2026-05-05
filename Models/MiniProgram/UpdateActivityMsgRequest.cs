using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 修改动态消息请求（POST /cgi-bin/message/wxopen/updatablemsg/update）
/// </summary>
public sealed class UpdateActivityMsgRequest
{
    /// <summary>动态消息的activity_id</summary>
    [JsonPropertyName("activity_id")] public required string ActivityId { get; set; }
    /// <summary>消息状态（0未开始 1已开始 2已取消 3已完结）</summary>
    [JsonPropertyName("target_state")] public required int TargetState { get; set; }
    /// <summary>需要更新的状态信息</summary>
    [JsonPropertyName("template_info")] public TemplateInfo? TemplateInfo { get; set; }
}

public sealed class TemplateInfo
{
    /// <summary>消息内容列表</summary>
    [JsonPropertyName("parameter_list")] public List<ParameterItem>? ParameterList { get; set; }
}

public sealed class ParameterItem
{
    /// <summary>关键词顺序</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    /// <summary>消息内容</summary>
    [JsonPropertyName("value")] public required string Value { get; set; }
}
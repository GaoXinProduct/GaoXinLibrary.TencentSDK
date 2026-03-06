using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>右上角更多操作按钮</summary>
public class TemplateCardActionMenu
{
    /// <summary>更多操作界面的描述</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }

    /// <summary>操作列表（最多3个）</summary>
    [JsonPropertyName("action_list")] public TemplateCardActionItem[]? ActionList { get; set; }
}


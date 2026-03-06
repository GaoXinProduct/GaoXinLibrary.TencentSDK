using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>模版卡片事件推送</summary>
public class CallbackTemplateCardEvent : CallbackEventBase
{
    /// <summary>与发送模版卡片消息时指定的 task_id 对应</summary>
    public string TaskId { get; set; } = string.Empty;

    /// <summary>事件 KEY 值（按钮 key / 选项 id 等）</summary>
    public string EventKey { get; set; } = string.Empty;

    /// <summary>模版卡片类型</summary>
    public string? CardType { get; set; }

    /// <summary>用于更新卡片消息的 response_code</summary>
    public string? ResponseCode { get; set; }

    /// <summary>用户选择的选项列表（投票/多选型）</summary>
    public TemplateCardSelectedItem[]? SelectedItems { get; set; }
}


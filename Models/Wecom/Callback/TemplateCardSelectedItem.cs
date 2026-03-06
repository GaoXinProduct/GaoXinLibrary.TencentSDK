using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>模版卡片事件中用户选择的选项</summary>
public class TemplateCardSelectedItem
{
    /// <summary>问题 key</summary>
    public string QuestionKey { get; set; } = string.Empty;

    /// <summary>选项 ID 列表</summary>
    public string[]? OptionIds { get; set; }
}


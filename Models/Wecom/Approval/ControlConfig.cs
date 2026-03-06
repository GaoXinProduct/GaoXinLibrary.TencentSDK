using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>控件配置</summary>
public class ControlConfig
{
    /// <summary>Date 控件专属：日期选择类型</summary>
    [JsonPropertyName("date")] public DateConfig? Date { get; set; }

    /// <summary>Selector 控件专属：选项配置</summary>
    [JsonPropertyName("selector")] public SelectorConfig? Selector { get; set; }
}


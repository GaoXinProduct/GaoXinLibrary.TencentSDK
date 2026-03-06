using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>模板控件</summary>
public class TemplateControl
{
    /// <summary>控件类型</summary>
    [JsonPropertyName("property")] public ControlProperty? Property { get; set; }

    /// <summary>模板配置信息</summary>
    [JsonPropertyName("config")] public ControlConfig? Config { get; set; }
}


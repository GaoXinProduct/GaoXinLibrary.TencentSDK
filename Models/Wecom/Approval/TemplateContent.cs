using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>模板控件内容</summary>
public class TemplateContent
{
    /// <summary>控件列表</summary>
    [JsonPropertyName("controls")] public TemplateControl[]? Controls { get; set; }
}


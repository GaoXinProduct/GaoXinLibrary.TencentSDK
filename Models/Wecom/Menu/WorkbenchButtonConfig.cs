using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台功能按钮型配置</summary>
public class WorkbenchButtonConfig
{
    /// <summary>按钮列表，最多4个</summary>
    [JsonPropertyName("buttons")] public WorkbenchButton[]? Buttons { get; set; }
}


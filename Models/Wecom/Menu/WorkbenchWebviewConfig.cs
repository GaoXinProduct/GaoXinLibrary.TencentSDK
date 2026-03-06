using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台网页型配置</summary>
public class WorkbenchWebviewConfig
{
    /// <summary>网页 URL</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
}


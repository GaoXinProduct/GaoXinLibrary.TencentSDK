using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台图片型配置</summary>
public class WorkbenchImageConfig
{
    /// <summary>图片 URL，最多2个</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
}


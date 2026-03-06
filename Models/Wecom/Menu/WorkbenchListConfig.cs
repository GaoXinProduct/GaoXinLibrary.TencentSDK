using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台列表型配置</summary>
public class WorkbenchListConfig
{
    /// <summary>列表项列表，最多5个</summary>
    [JsonPropertyName("item")] public WorkbenchListItem[]? Item { get; set; }
}


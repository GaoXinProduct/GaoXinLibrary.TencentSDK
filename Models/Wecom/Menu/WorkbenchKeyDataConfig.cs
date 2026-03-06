using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台关键数据型配置</summary>
public class WorkbenchKeyDataConfig
{
    /// <summary>关键数据项列表，最多4个</summary>
    [JsonPropertyName("items")] public WorkbenchKeyDataItem[]? Items { get; set; }
}


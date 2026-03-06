using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>日期控件配置</summary>
public class DateConfig
{
    /// <summary>日期类型：day / hour</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }
}


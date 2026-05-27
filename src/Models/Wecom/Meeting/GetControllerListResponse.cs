using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取控制器列表响应</summary>
/// <remarks>doc path: /98799</remarks>
public class GetControllerListResponse : WecomBaseResponse
{
    /// <summary>控制器列表</summary>
    [JsonPropertyName("controllers")]
    public List<ControllerInfo>? Controllers { get; set; }
}

/// <summary>控制器信息</summary>
public class ControllerInfo
{
    /// <summary>控制器ID</summary>
    [JsonPropertyName("controller_id")]
    public string? ControllerId { get; set; }

    /// <summary>控制器名称</summary>
    [JsonPropertyName("controller_name")]
    public string? ControllerName { get; set; }

    /// <summary>控制器类型：1-触控屏，2-遥控器</summary>
    [JsonPropertyName("controller_type")]
    public int ControllerType { get; set; }

    /// <summary>控制器状态：0-未知，1-在线，2-离线</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }
}
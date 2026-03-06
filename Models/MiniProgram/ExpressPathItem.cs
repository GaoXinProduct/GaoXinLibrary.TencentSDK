using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>轨迹节点</summary>
public class ExpressPathItem
{
    /// <summary>轨迹节点时间戳</summary>
    [JsonPropertyName("action_time")] public long ActionTime { get; set; }
    /// <summary>轨迹节点类型</summary>
    [JsonPropertyName("action_type")] public int ActionType { get; set; }
    /// <summary>轨迹节点详情</summary>
    [JsonPropertyName("action_msg")] public string? ActionMsg { get; set; }
}


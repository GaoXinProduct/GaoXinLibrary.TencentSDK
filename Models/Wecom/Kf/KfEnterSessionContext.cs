using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>进入会话场景信息</summary>
public class KfEnterSessionContext
{
    /// <summary>进入会话的场景值</summary>
    [JsonPropertyName("scene")] public string? Scene { get; set; }

    /// <summary>进入会话的自定义参数</summary>
    [JsonPropertyName("scene_param")] public string? SceneParam { get; set; }
}


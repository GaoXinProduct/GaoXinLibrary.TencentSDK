using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取访问来源响应（POST /wxaapi/log/get_scene）</summary>
public class GetSceneListResponse : WechatBaseResponse
{
    /// <summary>访问来源列表</summary>
    [JsonPropertyName("scene_list")] public List<SceneItem>? SceneList { get; set; }
}

/// <summary>访问来源项</summary>
public class SceneItem
{
    /// <summary>场景值</summary>
    [JsonPropertyName("scene")]   public int Scene { get; set; }
    /// <summary>场景名称</summary>
    [JsonPropertyName("name")]    public string? Name { get; set; }
    /// <summary>访问次数</summary>
    [JsonPropertyName("count")]   public int Count { get; set; }
}

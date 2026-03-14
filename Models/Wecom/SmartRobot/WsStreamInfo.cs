using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 流式消息信息
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsStreamInfo
{
    /// <summary>流式消息唯一标识（由开发者生成，同一 stream.id 关联同一条流式消息）</summary>
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;

    /// <summary>是否结束流式消息（设为 true 后消息不可再更新）</summary>
    [JsonPropertyName("finish")] public bool Finish { get; set; }

    /// <summary>流式消息内容</summary>
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

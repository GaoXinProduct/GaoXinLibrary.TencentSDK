using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 智能机器人长连接 WebSocket 请求帧
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
/// <typeparam name="T">body 数据类型</typeparam>
public class WsRequest<T>
{
    /// <summary>命令类型（参见 <see cref="WsCommands"/>）</summary>
    [JsonPropertyName("cmd")] public string Cmd { get; set; } = string.Empty;

    /// <summary>消息头部</summary>
    [JsonPropertyName("headers")] public WsHeaders Headers { get; set; } = new();

    /// <summary>消息体</summary>
    [JsonPropertyName("body")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Body { get; set; }
}

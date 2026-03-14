using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// WebSocket 消息头部
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsHeaders
{
    /// <summary>请求唯一标识，由开发者自行生成，用于关联请求和响应</summary>
    [JsonPropertyName("req_id")] public string ReqId { get; set; } = string.Empty;
}

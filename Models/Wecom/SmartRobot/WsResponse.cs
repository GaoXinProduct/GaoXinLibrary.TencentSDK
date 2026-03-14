using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 智能机器人长连接 WebSocket 响应帧
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsResponse
{
    /// <summary>消息头部</summary>
    [JsonPropertyName("headers")] public WsHeaders? Headers { get; set; }

    /// <summary>错误码，0 表示成功</summary>
    [JsonPropertyName("errcode")] public int ErrCode { get; set; }

    /// <summary>错误信息，成功时为 "ok"</summary>
    [JsonPropertyName("errmsg")] public string? ErrMsg { get; set; }
}

/// <summary>
/// 带 body 的 WebSocket 响应帧
/// </summary>
/// <typeparam name="T">body 数据类型</typeparam>
public class WsResponse<T> : WsResponse
{
    /// <summary>响应体</summary>
    [JsonPropertyName("body")] public T? Body { get; set; }
}

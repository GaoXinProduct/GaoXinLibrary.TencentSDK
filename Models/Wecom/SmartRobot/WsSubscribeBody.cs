using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_subscribe 请求体
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsSubscribeBody
{
    /// <summary>智能机器人的 BotID</summary>
    [JsonPropertyName("bot_id")] public string BotId { get; set; } = string.Empty;

    /// <summary>长连接专用密钥 Secret</summary>
    [JsonPropertyName("secret")] public string Secret { get; set; } = string.Empty;
}

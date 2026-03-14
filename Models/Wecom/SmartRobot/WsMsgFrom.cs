using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 消息发送者信息
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsMsgFrom
{
    /// <summary>消息发送者的 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
}

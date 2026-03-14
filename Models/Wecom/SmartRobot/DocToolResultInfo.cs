using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 文档工具调用结果
/// <para>
/// 开发者执行文档工具后，将结果通过此结构回传给企业微信。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101468"/>
/// </para>
/// </summary>
public class DocToolResultInfo
{
    /// <summary>工具调用唯一 ID，需透传自 <see cref="DocToolCallInfo.ToolCallId"/></summary>
    [JsonPropertyName("tool_call_id")] public string ToolCallId { get; set; } = string.Empty;

    /// <summary>工具执行结果内容（JSON 字符串）</summary>
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

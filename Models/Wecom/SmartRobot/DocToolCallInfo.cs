using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 文档工具调用信息
/// <para>
/// 当智能机器人 AI 决定调用文档工具时，该信息通过消息回调传递给开发者。
/// 开发者根据 <see cref="ToolName"/> 执行对应操作，并将结果回传。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101468"/>
/// </para>
/// </summary>
public class DocToolCallInfo
{
    /// <summary>工具调用唯一 ID，回传结果时需要透传</summary>
    [JsonPropertyName("tool_call_id")] public string ToolCallId { get; set; } = string.Empty;

    /// <summary>工具名称（参见 <see cref="DocToolNames"/>）</summary>
    [JsonPropertyName("tool_name")] public string ToolName { get; set; } = string.Empty;

    /// <summary>工具调用参数（JSON 对象，具体结构由 tool_name 决定）</summary>
    [JsonPropertyName("arguments")] public JsonElement? Arguments { get; set; }
}

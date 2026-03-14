using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_respond_tool_result 回传文档工具调用结果消息体
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101468"/></para>
/// </summary>
public class WsRespondToolResultBody
{
    /// <summary>工具调用结果列表</summary>
    [JsonPropertyName("tool_results")] public DocToolResultInfo[] ToolResults { get; set; } = [];
}

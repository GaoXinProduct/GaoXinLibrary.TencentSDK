using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 获取智能表格自动化创建的群聊会话响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101028"/></para>
/// </summary>
public class GetSmartSheetChatResponse : WecomBaseResponse
{
    /// <summary>群聊信息</summary>
    [JsonPropertyName("chat_info")] public GroupChatInfo? ChatInfo { get; set; }
}

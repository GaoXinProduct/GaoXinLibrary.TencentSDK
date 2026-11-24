using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 获取智能表格自动化创建的群聊会话响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101028"/></para>
/// </summary>
public sealed class GetSmartSheetChatResponse : WecomBaseResponse
{
    /// <summary>群聊信息，供原有调用方读取。</summary>
    [JsonPropertyName("chat_info")] public GroupChatInfo? ChatInfo { get; set; }

    /// <summary>群聊名称。</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>群主 userid。</summary>
    [JsonPropertyName("owner")] public string? Owner { get; set; }

    /// <summary>群内当前企业的成员 userid。</summary>
    [JsonPropertyName("user_list")] public string[]? UserList { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

/// <summary>获取群聊会话响应</summary>
public class GetGroupChatResponse : WecomBaseResponse
{
    /// <summary>群聊信息</summary>
    [JsonPropertyName("chat_info")] public GroupChatInfo? ChatInfo { get; set; }
}


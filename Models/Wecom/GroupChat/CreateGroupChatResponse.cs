using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

#region 响应模型

/// <summary>创建群聊会话响应</summary>
public class CreateGroupChatResponse : WecomBaseResponse
{
    /// <summary>群聊唯一标识</summary>
    [JsonPropertyName("chat_info")] public GroupChatInfo? ChatInfo { get; set; }
}

#endregion

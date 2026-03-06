using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

// ─── 请求模型 ──────────────────────────────────────────────────────────────

/// <summary>创建群聊会话请求</summary>
public class CreateGroupChatRequest
{
    /// <summary>群聊名称（最多50个utf8字符，超过将截断）</summary>
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

    /// <summary>群主 userid，必填</summary>
    [JsonPropertyName("owner")] public string Owner { get; set; } = string.Empty;

    /// <summary>群成员 userid 列表，至少2人，至多2000人</summary>
    [JsonPropertyName("userlist")] public string[] UserList { get; set; } = [];

    /// <summary>群聊 ID，不填时由企业微信自动生成；仅可由数字、字母和"_-."三种特殊字符组成，长度限制在1至64字节之间</summary>
    [JsonPropertyName("chatid")] public string? ChatId { get; set; }
}


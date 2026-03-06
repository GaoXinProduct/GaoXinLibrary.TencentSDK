using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

// ─── 群聊信息 ──────────────────────────────────────────────────────────────

/// <summary>群聊信息</summary>
public class GroupChatInfo
{
    /// <summary>群聊唯一标识，由企业微信分配</summary>
    [JsonPropertyName("chatid")] public string ChatId { get; set; } = string.Empty;

    /// <summary>群聊名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>群主 userid</summary>
    [JsonPropertyName("owner")] public string? Owner { get; set; }

    /// <summary>群成员 userid 列表</summary>
    [JsonPropertyName("userlist")] public string[]? UserList { get; set; }
}


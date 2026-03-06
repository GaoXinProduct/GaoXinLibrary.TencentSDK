using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>单条会话记录（加密状态）</summary>
public class ChatDataItem
{
    /// <summary>消息的 seq 值，用于翻页续拉</summary>
    [JsonPropertyName("seq")] public long Seq { get; set; }

    /// <summary>消息 id</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }

    /// <summary>消息加密版本号</summary>
    [JsonPropertyName("publickey_ver")] public int PublicKeyVer { get; set; }

    /// <summary>RSA 加密后的消息密钥，需用对应版本私钥解密</summary>
    [JsonPropertyName("encrypt_random_key")] public string? EncryptRandomKey { get; set; }

    /// <summary>加密后的消息内容，需先用 encrypt_random_key 解密</summary>
    [JsonPropertyName("encrypt_chat_msg")] public string? EncryptChatMsg { get; set; }
}


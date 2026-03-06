using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>GetChatData 返回的 JSON 根对象</summary>
public class ChatDataListResult
{
    /// <summary>错误码，0 表示成功</summary>
    [JsonPropertyName("errcode")] public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    [JsonPropertyName("errmsg")] public string? ErrMsg { get; set; }

    /// <summary>会话记录列表</summary>
    [JsonPropertyName("chatdata")] public ChatDataItem[]? ChatData { get; set; }
}


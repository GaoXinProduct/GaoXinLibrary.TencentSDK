using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>接收消息请求（同步消息）</summary>
public class KfSyncMsgRequest
{
    /// <summary>上一次调用时返回的 next_cursor，首次调用可不填</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }

    /// <summary>期望请求的数据量，默认1000，最大1000</summary>
    [JsonPropertyName("limit")] public int? Limit { get; set; }

    /// <summary>回调事件的 token</summary>
    [JsonPropertyName("token")] public string? Token { get; set; }

    /// <summary>客服账号 id（非必填，不填则拉取所有客服账号的消息）</summary>
    [JsonPropertyName("open_kfid")] public string? OpenKfId { get; set; }

    /// <summary>语音消息类型 0-Amr 1-Silk</summary>
    [JsonPropertyName("voice_format")] public int? VoiceFormat { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>接收消息响应</summary>
public class KfSyncMsgResponse : WecomBaseResponse
{
    /// <summary>下次调用带上该值翻页</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")] public int HasMore { get; set; }

    /// <summary>消息列表</summary>
    [JsonPropertyName("msg_list")] public KfMessage[]? MsgList { get; set; }
}


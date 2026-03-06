using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询群发消息发送状态响应</summary>
public class MassGetResponse : WechatBaseResponse
{
    [JsonPropertyName("msg_id")] public long MsgId { get; set; }
    /// <summary>消息发送后的状态：SEND_SUCCESS / SENDING / SEND_FAIL / DELETE</summary>
    [JsonPropertyName("msg_status")] public string? MsgStatus { get; set; }
}


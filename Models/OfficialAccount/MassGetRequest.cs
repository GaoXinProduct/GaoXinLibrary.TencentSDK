using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询群发消息发送状态请求（POST /cgi-bin/message/mass/get）</summary>
public class MassGetRequest
{
    [JsonPropertyName("msg_id")] public required long MsgId { get; set; }
}


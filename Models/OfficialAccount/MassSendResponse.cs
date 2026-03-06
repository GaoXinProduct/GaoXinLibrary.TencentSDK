using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>群发消息响应</summary>
public class MassSendResponse : WechatBaseResponse
{
    [JsonPropertyName("msg_id")] public long MsgId { get; set; }
    [JsonPropertyName("msg_data_id")] public long MsgDataId { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>消息发送概况数据项</summary>
public class UpstreamMsgItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("msg_type")] public int MsgType { get; set; }
    [JsonPropertyName("msg_user")] public int MsgUser { get; set; }
    [JsonPropertyName("msg_count")] public int MsgCount { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>群发消息请求 — 根据 OpenId 列表发送（POST /cgi-bin/message/mass/send）</summary>
public class MassSendRequest
{
    [JsonPropertyName("touser")] public required List<string> ToUser { get; set; }
    [JsonPropertyName("msgtype")] public required string MsgType { get; set; }
    [JsonPropertyName("text")] public CustomMsgText? Text { get; set; }
    [JsonPropertyName("mpnews")] public CustomMsgMpNews? MpNews { get; set; }
    [JsonPropertyName("mpvideo")] public CustomMsgMedia? MpVideo { get; set; }
    [JsonPropertyName("voice")] public CustomMsgMedia? Voice { get; set; }
    [JsonPropertyName("images")] public MassImages? Images { get; set; }
    [JsonPropertyName("send_ignore_reprint")] public int SendIgnoreReprint { get; set; }
}


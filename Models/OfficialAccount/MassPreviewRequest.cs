using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>预览群发消息请求（POST /cgi-bin/message/mass/preview）</summary>
public class MassPreviewRequest
{
    [JsonPropertyName("touser")] public required string ToUser { get; set; }
    [JsonPropertyName("msgtype")] public required string MsgType { get; set; }
    [JsonPropertyName("text")] public CustomMsgText? Text { get; set; }
    [JsonPropertyName("mpnews")] public CustomMsgMpNews? MpNews { get; set; }
    [JsonPropertyName("voice")] public CustomMsgMedia? Voice { get; set; }
}


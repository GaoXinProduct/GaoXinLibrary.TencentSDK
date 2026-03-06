using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发送模板消息响应
/// </summary>
public class SendTemplateMessageResponse : WechatBaseResponse
{
    /// <summary>消息 ID</summary>
    [JsonPropertyName("msgid")] public long MsgId { get; set; }
}


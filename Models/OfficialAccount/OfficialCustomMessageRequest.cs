using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发送客服消息请求（POST /cgi-bin/message/custom/send）
/// <para>
/// 不同消息类型需要填写不同字段，如文本消息设置 Text 属性，图片消息设置 Image 属性等。
/// </para>
/// </summary>
public class OfficialCustomMessageRequest
{
    [JsonPropertyName("touser")] public required string ToUser { get; set; }
    [JsonPropertyName("msgtype")] public required string MsgType { get; set; }
    [JsonPropertyName("text")] public CustomMsgText? Text { get; set; }
    [JsonPropertyName("image")] public CustomMsgMedia? Image { get; set; }
    [JsonPropertyName("voice")] public CustomMsgMedia? Voice { get; set; }
    [JsonPropertyName("video")] public CustomMsgVideo? Video { get; set; }
    [JsonPropertyName("music")] public CustomMsgMusic? Music { get; set; }
    [JsonPropertyName("news")] public CustomMsgNews? News { get; set; }
    [JsonPropertyName("mpnews")] public CustomMsgMpNews? MpNews { get; set; }
    [JsonPropertyName("miniprogrampage")] public CustomMsgMiniProgram? MiniProgramPage { get; set; }
    /// <summary>指定客服账号（可选）</summary>
    [JsonPropertyName("customservice")] public CustomServiceAccount? CustomService { get; set; }
}


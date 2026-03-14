using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_respond_update_msg 更新模板卡片消息体
/// <para>收到 template_card_event 事件后 5 秒内回复。</para>
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsRespondUpdateMsgBody
{
    /// <summary>响应类型，固定值 update_template_card</summary>
    [JsonPropertyName("response_type")] public string ResponseType { get; set; } = "update_template_card";

    /// <summary>模板卡片结构体</summary>
    [JsonPropertyName("template_card")] public JsonElement TemplateCard { get; set; }
}

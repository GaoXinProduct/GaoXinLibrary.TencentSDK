using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>创建群发响应</summary>
public sealed class AddMsgTemplateResponse : WecomBaseResponse
{
    [JsonPropertyName("msgid")] public string MsgId { get; set; } = string.Empty;
    [JsonPropertyName("fail_list")] public string[]? FailList { get; set; }
}

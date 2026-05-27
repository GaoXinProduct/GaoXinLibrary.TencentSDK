using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>opengid转换响应</summary>
public sealed class ConvertOpengIdResponse : WecomBaseResponse
{
    [JsonPropertyName("chat_id")] public string? ChatId { get; set; }
}

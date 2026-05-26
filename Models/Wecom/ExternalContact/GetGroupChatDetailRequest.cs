namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取客户群详情请求</summary>
public sealed class GetGroupChatDetailRequest
{
    [JsonPropertyName("chat_id")] public string ChatId { get; set; } = string.Empty;
    [JsonPropertyName("need_name")] public int NeedName { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>客户群列表项</summary>
public class GroupChatItem
{
    /// <summary>客户群ID</summary>
    [JsonPropertyName("chat_id")] public string? ChatId { get; set; }

    /// <summary>客户群状态，0-正常，1-跟进人离职，2-离职继承中，3-离职继承完成</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
}

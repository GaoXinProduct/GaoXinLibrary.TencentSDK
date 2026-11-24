namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>查询智能表格自动化创建的群聊。</summary>
public sealed class GetSmartSheetChatRequest
{
    /// <summary>创建群聊的智能表格文档 ID。</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>智能表格自动化创建的群聊 ID。</summary>
    [JsonPropertyName("chat_id")] public string ChatId { get; set; } = string.Empty;
}

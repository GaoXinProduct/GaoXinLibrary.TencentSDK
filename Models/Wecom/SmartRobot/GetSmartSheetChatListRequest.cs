using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 获取智能表格自动化创建的群聊列表请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100989"/></para>
/// </summary>
public class GetSmartSheetChatListRequest
{
    /// <summary>智能表格 docid</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>子表 sheet_id</summary>
    [JsonPropertyName("sheet_id")] public string SheetId { get; set; } = string.Empty;

    /// <summary>偏移量，默认为 0</summary>
    [JsonPropertyName("offset")] public int Offset { get; set; }

    /// <summary>每页拉取数量，默认 100，最大 1000</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 100;
}

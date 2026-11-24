
namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 获取智能表格自动化创建的群聊列表请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100989"/></para>
/// </summary>
public sealed class GetSmartSheetChatListRequest
{
    /// <summary>智能表格 docid</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>旧版子表字段。官方群聊列表按文档查询，请留空。</summary>
    [JsonPropertyName("sheet_id")] public string SheetId { get; set; } = string.Empty;

    /// <summary>旧版偏移量。官方接口使用 <see cref="Cursor"/>，请保留默认值 0。</summary>
    [JsonPropertyName("offset")] public int Offset { get; set; }

    /// <summary>上一次查询返回的游标，首次查询可省略。</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }

    /// <summary>每页拉取数量，默认 100，最大 200</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 100;
}

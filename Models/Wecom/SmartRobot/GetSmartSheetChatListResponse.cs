using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 获取智能表格自动化创建的群聊列表响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100989"/></para>
/// </summary>
public class GetSmartSheetChatListResponse : WecomBaseResponse
{
    /// <summary>群聊 ID 列表</summary>
    [JsonPropertyName("chat_id_list")] public string[]? ChatIdList { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>下次拉取的偏移量</summary>
    [JsonPropertyName("next_offset")] public int NextOffset { get; set; }
}

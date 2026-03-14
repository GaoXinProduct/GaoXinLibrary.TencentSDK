using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 修改智能表格自动化创建的群聊会话请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101029"/></para>
/// </summary>
public class UpdateSmartSheetChatRequest
{
    /// <summary>群聊唯一标识</summary>
    [JsonPropertyName("chatid")] public string ChatId { get; set; } = string.Empty;

    /// <summary>新的群聊名称（不超过50个utf8字符），不填时不修改</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>新的群主 userid，不填时不修改</summary>
    [JsonPropertyName("owner")] public string? Owner { get; set; }

    /// <summary>添加成员的 userid 列表，不填时不修改</summary>
    [JsonPropertyName("add_user_list")] public string[]? AddUserList { get; set; }

    /// <summary>踢出成员的 userid 列表，不填时不修改</summary>
    [JsonPropertyName("del_user_list")] public string[]? DelUserList { get; set; }
}

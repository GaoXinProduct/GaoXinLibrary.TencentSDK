using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

#region 更新模版卡片消息

/// <summary>更新模版卡片消息请求</summary>
public class UpdateTemplateCardRequest
{
    /// <summary>应用 agentid</summary>
    [JsonPropertyName("agentid")] public int AgentId { get; set; }

    /// <summary>需要更新的成员 userid 列表，最多1000个</summary>
    [JsonPropertyName("userids")] public string[]? UserIds { get; set; }

    /// <summary>需要更新的成员所在部门 ID 列表，最多100个</summary>
    [JsonPropertyName("partyids")] public int[]? PartyIds { get; set; }

    /// <summary>需要更新的成员所在标签 ID 列表，最多100个</summary>
    [JsonPropertyName("tagids")] public int[]? TagIds { get; set; }

    /// <summary>模版卡片消息发送时所使用的 response_code</summary>
    [JsonPropertyName("response_code")] public string? ResponseCode { get; set; }

    /// <summary>替换整个卡片的名称，不填时默认为 "消息已更新"</summary>
    [JsonPropertyName("replace_name")] public string? ReplaceName { get; set; }

    /// <summary>卡片右下角的按钮配置</summary>
    [JsonPropertyName("button")] public TemplateCardButton? Button { get; set; }

    /// <summary>是否跳转 url，0=否, 1=是</summary>
    [JsonPropertyName("is_replace")] public int IsReplace { get; set; }
}

#endregion

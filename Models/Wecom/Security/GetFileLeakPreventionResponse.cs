using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>文件防泄漏规则响应</summary>
public class GetFileLeakPreventionResponse : WecomBaseResponse
{
    /// <summary>文件防泄漏规则列表</summary>
    [JsonPropertyName("rule_list")] public FileLeakPreventionRule[]? RuleList { get; set; }
}

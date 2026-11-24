namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>旧版文件防泄漏方法的响应，包含文件操作记录。</summary>
public sealed class GetFileLeakPreventionResponse : GetFileOperationRecordsResponse
{
    /// <summary>历史规则列表字段。文件操作记录见 <see cref="GetFileOperationRecordsResponse.RecordList"/>。</summary>
    [JsonPropertyName("rule_list")] public FileLeakPreventionRule[]? RuleList { get; set; }
}

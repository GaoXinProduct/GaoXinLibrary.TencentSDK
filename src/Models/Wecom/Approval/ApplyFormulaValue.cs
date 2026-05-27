using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>公式控件值（后台自动计算，提交时无需填写）</summary>
public sealed class ApplyFormulaValue
{
    /// <summary>公式计算结果值</summary>
    [JsonPropertyName("value")] public string? Value { get; set; }
}

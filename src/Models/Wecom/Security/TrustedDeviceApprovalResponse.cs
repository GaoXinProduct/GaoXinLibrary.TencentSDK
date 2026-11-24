using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>通过或驳回设备申请的结果。</summary>
public sealed class TrustedDeviceApprovalResponse : WecomBaseResponse
{
    /// <summary>成功处理的设备标识。</summary>
    [JsonPropertyName("success_list")] public string[]? SuccessList { get; set; }

    /// <summary>处理失败的设备标识。</summary>
    [JsonPropertyName("fail_list")] public string[]? FailList { get; set; }
}

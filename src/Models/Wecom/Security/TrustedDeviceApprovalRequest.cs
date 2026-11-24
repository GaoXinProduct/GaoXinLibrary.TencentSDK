namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>通过或驳回设备申请的请求。</summary>
public sealed class TrustedDeviceApprovalRequest
{
    /// <summary>待审批的设备标识列表。</summary>
    [JsonPropertyName("device_code_list")] public required string[] DeviceCodeList { get; init; }
}

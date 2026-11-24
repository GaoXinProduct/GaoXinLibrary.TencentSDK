using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>可信设备批量导入结果。</summary>
public sealed class ImportTrustedDevicesResponse : WecomBaseResponse
{
    /// <summary>每台待导入设备的结果。</summary>
    [JsonPropertyName("result")] public TrustedDeviceImportResult[]? Results { get; set; }
}

/// <summary>一台可信设备的导入结果。</summary>
public sealed class TrustedDeviceImportResult
{
    /// <summary>设备在请求列表中的序号，从 1 开始。</summary>
    [JsonPropertyName("device_index")] public int DeviceIndex { get; set; }

    /// <summary>导入成功的设备标识。</summary>
    [JsonPropertyName("device_code")] public string? DeviceCode { get; set; }

    /// <summary>重复导入时已有设备的标识。</summary>
    [JsonPropertyName("duplicated_device_code")] public string? DuplicatedDeviceCode { get; set; }

    /// <summary>导入状态，1 为成功，2 为重复，3 为不支持，4 为数据格式错误。</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
}

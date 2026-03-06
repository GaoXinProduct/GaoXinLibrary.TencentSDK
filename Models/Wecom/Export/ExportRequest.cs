using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Export;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>导出请求基类</summary>
public class ExportRequest
{
    /// <summary>
    /// base64encode 的加密密钥，长度固定为 43，
    /// 加密方法与企业微信回调接收消息中的 EncodingAESKey 一致
    /// </summary>
    [JsonPropertyName("encoding_aeskey")] public string EncodingAesKey { get; set; } = string.Empty;

    /// <summary>
    /// 每块数据的人员数和部门数之和，支持范围 [10^4, 10^6]，默认 10^6
    /// </summary>
    [JsonPropertyName("block_size")] public int? BlockSize { get; set; }
}


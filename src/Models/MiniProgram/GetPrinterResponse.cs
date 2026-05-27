using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取打印员响应
/// </summary>
public sealed class GetPrinterResponse : WechatBaseResponse
{
    /// <summary>打印机ID列表</summary>
    [JsonPropertyName("printer_list")] public List<PrinterInfo>? PrinterList { get; init; }
}

/// <summary>
/// 打印机信息
/// </summary>
public sealed class PrinterInfo
{
    /// <summary>打印机ID</summary>
    [JsonPropertyName("printer_id")] public string? PrinterId { get; init; }
    /// <summary>打印机名称</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }
    /// <summary>打印机状态（0正常 1异常）</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
    /// <summary>备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; init; }
}
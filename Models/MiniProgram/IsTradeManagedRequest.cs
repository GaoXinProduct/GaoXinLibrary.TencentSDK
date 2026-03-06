using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询小程序是否已完成交易结算管理确认请求（POST /wxa/sec/order/is_trade_managed）
/// </summary>
public class IsTradeManagedRequest
{
    /// <summary>小程序 AppId</summary>
    [JsonPropertyName("appid")] public required string AppId { get; set; }
}


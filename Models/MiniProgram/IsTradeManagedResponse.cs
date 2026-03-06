using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询小程序是否已完成交易结算管理确认响应
/// </summary>
public class IsTradeManagedResponse : WechatBaseResponse
{
    /// <summary>是否已完成交易结算管理确认</summary>
    [JsonPropertyName("is_trade_managed")] public bool IsTradeManaged { get; set; }
}


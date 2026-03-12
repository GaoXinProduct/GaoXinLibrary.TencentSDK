using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 创建发票卡券模板响应
/// </summary>
public class InvoicePlatformCreateCardResponse : WechatBaseResponse
{
    /// <summary>发票卡券模板编号</summary>
    [JsonPropertyName("card_id")] public string? CardId { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

/// <summary>
/// 获取 PC OpenSDK ticket 响应
/// </summary>
public class GetPcOpenSdkTicketResponse : WechatBaseResponse
{
    /// <summary>一次性接口调用票据，5 分钟内有效，仅可调用一次</summary>
    [JsonPropertyName("ticket")] public string? Ticket { get; set; }
}


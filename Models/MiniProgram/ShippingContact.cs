using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>发货联系方式</summary>
public class ShippingContact
{
    /// <summary>寄件人联系方式（采用掩码传输，例如 189****1234）</summary>
    [JsonPropertyName("consignor_contact")] public string? ConsignorContact { get; set; }

    /// <summary>收件人联系方式（采用掩码传输）</summary>
    [JsonPropertyName("receiver_contact")] public string? ReceiverContact { get; set; }
}


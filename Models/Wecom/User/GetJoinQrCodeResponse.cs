using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public class GetJoinQrCodeResponse : WecomBaseResponse
{
    [JsonPropertyName("join_qrcode")] public string? JoinQrCode { get; set; }
}


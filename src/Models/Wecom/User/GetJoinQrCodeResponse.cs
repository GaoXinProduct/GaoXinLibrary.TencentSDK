using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public sealed class GetJoinQrCodeResponse : WecomBaseResponse
{
    [JsonPropertyName("join_qrcode")] public string? JoinQrCode { get; set; }
}


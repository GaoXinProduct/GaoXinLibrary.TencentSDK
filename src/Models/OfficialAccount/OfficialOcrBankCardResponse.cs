using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>OCR — 银行卡识别响应</summary>
public sealed class OfficialOcrBankCardResponse : WechatBaseResponse
{
    [JsonPropertyName("number")] public string? Number { get; set; }
}


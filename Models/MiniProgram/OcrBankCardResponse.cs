using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>银行卡 OCR 响应（POST /cv/ocr/bankcard）</summary>
public class OcrBankCardResponse : WechatBaseResponse
{
    /// <summary>银行卡号</summary>
    [JsonPropertyName("number")] public string? Number { get; set; }
}


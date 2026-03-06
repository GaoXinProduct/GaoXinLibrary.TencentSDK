using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取手机号请求（POST /wxa/business/getuserphonenumber）
/// </summary>
public class GetPhoneNumberRequest
{
    /// <summary>手机号获取凭证（前端 getPhoneNumber 返回的 code）</summary>
    [JsonPropertyName("code")] public required string Code { get; set; }
}


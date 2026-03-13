using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

/// <summary>获取二次验证信息请求</summary>
public class GetTfaInfoRequest
{
    /// <summary>验证码</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;
}

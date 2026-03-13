using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>通过手机号获取 userid 请求</summary>
public class GetUserIdByMobileRequest
{
    /// <summary>手机号</summary>
    [JsonPropertyName("mobile")]
    public string Mobile { get; set; } = string.Empty;
}

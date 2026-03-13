using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>获取设备信息请求</summary>
public class GetDeviceInfoRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}

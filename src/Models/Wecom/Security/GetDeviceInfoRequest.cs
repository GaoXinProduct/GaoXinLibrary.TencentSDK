
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>获取设备信息请求</summary>
public sealed class GetDeviceInfoRequest
{
    /// <summary>最后登录成员的企业微信账号。</summary>
    [JsonPropertyName("last_login_userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>设备类型，默认值为 1。</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; } = 1;

    [JsonInclude]
    [JsonPropertyName("userid")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    private string? LegacyUserId
    {
        get => null;
        set
        {
            if (value is not null && string.IsNullOrEmpty(UserId))
                UserId = value;
        }
    }
}

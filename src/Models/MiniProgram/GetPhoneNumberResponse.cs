using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取手机号响应
/// </summary>
public sealed class GetPhoneNumberResponse : WechatBaseResponse
{
    /// <summary>手机号信息</summary>
    [JsonPropertyName("phone_info")] public PhoneInfo? PhoneInfo { get; set; }
}


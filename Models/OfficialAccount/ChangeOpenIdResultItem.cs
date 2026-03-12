using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// OpenId 转换结果项
/// </summary>
public class ChangeOpenIdResultItem
{
    /// <summary>旧 OpenId</summary>
    [JsonPropertyName("ori_openid")] public string? OriOpenId { get; set; }

    /// <summary>新 OpenId</summary>
    [JsonPropertyName("new_openid")] public string? NewOpenId { get; set; }

    /// <summary>结果描述</summary>
    [JsonPropertyName("err_msg")] public string? ErrMsg { get; set; }
}

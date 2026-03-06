using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 设置用户备注名请求（POST /cgi-bin/user/info/updateremark）
/// </summary>
public class UpdateRemarkRequest
{
    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }

    /// <summary>新的备注名（最长 30 字符）</summary>
    [JsonPropertyName("remark")] public required string Remark { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

/// <summary>获取用户二次验证信息响应</summary>
public class GetTfaInfoResponse : WecomBaseResponse
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>用户状态，1-已激活 2-已禁用 4-未激活 5-退出企业</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
}

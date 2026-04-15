using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

#region 请求模型

/// <summary>创建成员请求</summary>
public class CreateUserRequest
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("alias")] public string? Alias { get; set; }
    [JsonPropertyName("mobile")] public string? Mobile { get; set; }
    [JsonPropertyName("department")] public int[] Department { get; set; } = [];
    [JsonPropertyName("position")] public string? Position { get; set; }
    [JsonPropertyName("gender")] public string? Gender { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("biz_mail")] public string? BizMail { get; set; }
    [JsonPropertyName("telephone")] public string? Telephone { get; set; }
    [JsonPropertyName("address")] public string? Address { get; set; }
    [JsonPropertyName("enable")] public int Enable { get; set; } = 1;
}

#endregion

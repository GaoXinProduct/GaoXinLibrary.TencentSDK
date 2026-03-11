using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>邮件地址</summary>
public class EmailAddress
{
    /// <summary>邮箱地址</summary>
    [JsonPropertyName("addr")] public string Addr { get; set; } = string.Empty;

    /// <summary>收件人名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
}

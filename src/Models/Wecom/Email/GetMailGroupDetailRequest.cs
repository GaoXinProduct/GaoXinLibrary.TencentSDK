using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取邮件群组详情请求</summary>
/// <remarks>文档路径: /document/path/97997</remarks>
public record GetMailGroupDetailRequest
{
    /// <summary>邮件群组ID</summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;
}
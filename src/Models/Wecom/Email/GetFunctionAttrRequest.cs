using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取用户功能属性请求</summary>
/// <remarks>文档路径: /document/path/95513</remarks>
public record GetFunctionAttrRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>功能属性，1=邮件，2=日程，3=联系人</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }
}
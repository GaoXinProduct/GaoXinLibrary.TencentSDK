using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>更改用户功能属性请求</summary>
/// <remarks>文档路径: /document/path/98008</remarks>
public record SetFunctionAttrRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>功能属性，1=邮件，2=日程，3=联系人</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>属性值</summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }
}
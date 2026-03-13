using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>修改客户备注请求</summary>
public class UpdateRemarkRequest
{
    /// <summary>企业成员 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>外部联系人 userid</summary>
    [JsonPropertyName("external_userid")]
    public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>备注</summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    /// <summary>描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

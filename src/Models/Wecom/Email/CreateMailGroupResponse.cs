using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>创建邮件群组响应</summary>
/// <remarks>文档路径: /document/path/95510</remarks>
public class CreateMailGroupResponse : WecomBaseResponse
{
    /// <summary>邮件群组ID</summary>
    [JsonPropertyName("group_id")]
    public string? GroupId { get; set; }
}
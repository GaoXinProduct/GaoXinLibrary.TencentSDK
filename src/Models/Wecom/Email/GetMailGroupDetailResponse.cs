using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取邮件群组详情响应</summary>
/// <remarks>文档路径: /document/path/97997</remarks>
public class GetMailGroupDetailResponse : WecomBaseResponse
{
    /// <summary>邮件群组信息</summary>
    [JsonPropertyName("group_info")]
    public MailGroupInfo? GroupInfo { get; set; }
}
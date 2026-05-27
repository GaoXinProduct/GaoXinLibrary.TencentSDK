using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取公共邮箱详情响应</summary>
/// <remarks>文档路径: /document/path/98002</remarks>
public class GetPublicMailboxDetailResponse : WecomBaseResponse
{
    /// <summary>公共邮箱信息</summary>
    [JsonPropertyName("mailbox_info")]
    public PublicMailboxInfo? MailboxInfo { get; set; }
}
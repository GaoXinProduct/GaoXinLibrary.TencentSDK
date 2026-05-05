using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取空间邀请链接响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97877</remarks>
public class GetSpaceInviteLinkResponse : WecomBaseResponse
{
    /// <summary>邀请链接</summary>
    [JsonPropertyName("share_url")]
    public string? ShareUrl { get; set; }
}
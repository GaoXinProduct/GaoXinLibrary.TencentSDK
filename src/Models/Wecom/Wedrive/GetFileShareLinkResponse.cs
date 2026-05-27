using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件分享链接响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97890</remarks>
public class GetFileShareLinkResponse : WecomBaseResponse
{
    /// <summary>分享链接</summary>
    [JsonPropertyName("share_url")]
    public string? ShareUrl { get; set; }

    /// <summary>分享设置，0-仅文件所有者可分享，1-任何人可分享</summary>
    [JsonPropertyName("share_mode")]
    public int ShareMode { get; set; }
}
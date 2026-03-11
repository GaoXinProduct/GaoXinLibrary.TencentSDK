using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.IpRange;

/// <summary>获取企业微信IP段响应</summary>
public class GetIpListResponse : WecomBaseResponse
{
    /// <summary>IP段列表</summary>
    [JsonPropertyName("ip_list")] public string[]? IpList { get; set; }
}

using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取企业微信服务器 IP 地址段响应</summary>
public class GetCallbackIpResponse : WecomBaseResponse
{
    /// <summary>企业微信回调的 IP 地址段列表</summary>
    [JsonPropertyName("ip_list")] public string[]? IpList { get; set; }
}


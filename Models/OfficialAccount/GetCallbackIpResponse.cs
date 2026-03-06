using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取微信服务器 IP 地址响应</summary>
public class GetCallbackIpResponse : WechatBaseResponse
{
    /// <summary>微信服务器 IP 地址列表</summary>
    [System.Text.Json.Serialization.JsonPropertyName("ip_list")]
    public string[]? IpList { get; set; }
}


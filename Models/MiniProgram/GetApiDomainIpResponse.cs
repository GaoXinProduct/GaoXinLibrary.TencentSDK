using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取微信API服务器IP响应（GET /cgi-bin/get_api_domain_ip）</summary>
public class GetApiDomainIpResponse : WechatBaseResponse
{
    /// <summary>微信API服务器IP地址列表</summary>
    [JsonPropertyName("ip_list")] public List<string>? IpList { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取微信推送服务器IP响应（GET /cgi-bin/getcallbackip）</summary>
public class GetCallbackIpResponse : WechatBaseResponse
{
    /// <summary>微信推送服务器IP地址列表</summary>
    [JsonPropertyName("ip_list")] public List<string>? IpList { get; set; }
}

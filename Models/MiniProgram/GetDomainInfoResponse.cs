using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>查询域名配置响应（GET /wxa/getwxadevinfo）</summary>
public class GetDomainInfoResponse : WechatBaseResponse
{
    /// <summary>小程序合法域名列表</summary>
    [JsonPropertyName("requestdomain")]   public List<string>? RequestDomain { get; set; }
    /// <summary>socket 合法域名列表</summary>
    [JsonPropertyName("wsrequestdomain")] public List<string>? WsRequestDomain { get; set; }
    /// <summary>上传文件合法域名列表</summary>
    [JsonPropertyName("uploaddomain")]    public List<string>? UploadDomain { get; set; }
    /// <summary>下载文件合法域名列表</summary>
    [JsonPropertyName("downloaddomain")]  public List<string>? DownloadDomain { get; set; }
    /// <summary>udp 合法域名列表</summary>
    [JsonPropertyName("udpdomain")]       public List<string>? UdpDomain { get; set; }
    /// <summary>tcp 合法域名列表</summary>
    [JsonPropertyName("tcpdomain")]       public List<string>? TcpDomain { get; set; }
}

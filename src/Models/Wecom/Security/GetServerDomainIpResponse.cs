using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>企业微信的域名和 IP 列表。</summary>
public sealed class GetServerDomainIpResponse : WecomBaseResponse
{
    /// <summary>域名及其用途。</summary>
    [JsonPropertyName("domain_list")] public ServerDomainInfo[]? DomainList { get; set; }

    /// <summary>IP 地址及其用途。</summary>
    [JsonPropertyName("ip_list")] public ServerIpInfo[]? IpList { get; set; }
}

/// <summary>企业微信域名的连接信息。</summary>
public sealed class ServerDomainInfo
{
    /// <summary>域名。</summary>
    [JsonPropertyName("domain")] public string? Domain { get; set; }

    /// <summary>泛域名，接口字段使用 universal_domian。</summary>
    [JsonPropertyName("universal_domian")] public string? UniversalDomain { get; set; }

    /// <summary>连接协议。</summary>
    [JsonPropertyName("protocol")] public string? Protocol { get; set; }

    /// <summary>端口列表。</summary>
    [JsonPropertyName("port")] public int[]? PortList { get; set; }

    /// <summary>是否为必要连接，1 为是，0 为否。</summary>
    [JsonPropertyName("is_necessary")] public int IsNecessary { get; set; }

    /// <summary>连接用途。</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }
}

/// <summary>企业微信 IP 地址的连接信息。</summary>
public sealed class ServerIpInfo
{
    /// <summary>IP 地址。</summary>
    [JsonPropertyName("ip")] public string? Ip { get; set; }

    /// <summary>连接协议。</summary>
    [JsonPropertyName("protocol")] public string? Protocol { get; set; }

    /// <summary>端口列表。</summary>
    [JsonPropertyName("port")] public int[]? PortList { get; set; }

    /// <summary>是否为必要连接，1 为是，0 为否。</summary>
    [JsonPropertyName("is_necessary")] public int IsNecessary { get; set; }

    /// <summary>连接用途。</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }
}

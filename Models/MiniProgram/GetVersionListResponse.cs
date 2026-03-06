using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取客户端版本响应（POST /wxaapi/log/get_client_version）</summary>
public class GetVersionListResponse : WechatBaseResponse
{
    /// <summary>客户端版本列表</summary>
    [JsonPropertyName("version_list")] public List<VersionItem>? VersionList { get; set; }
}

/// <summary>客户端版本项</summary>
public class VersionItem
{
    /// <summary>客户端版本号</summary>
    [JsonPropertyName("version")] public string? Version { get; set; }
    /// <summary>该版本访问次数</summary>
    [JsonPropertyName("count")]   public int Count { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 短链转长信息响应
/// </summary>
public class ShortLinkFetchResponse : WechatBaseResponse
{
    /// <summary>原始长信息</summary>
    [JsonPropertyName("long_data")] public string? LongData { get; set; }

    /// <summary>创建时间戳</summary>
    [JsonPropertyName("create_time")] public long? CreateTime { get; set; }

    /// <summary>过期秒数</summary>
    [JsonPropertyName("expire_seconds")] public int? ExpireSeconds { get; set; }
}

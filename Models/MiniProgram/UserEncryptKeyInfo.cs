using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>用户加密 key 信息</summary>
public class UserEncryptKeyInfo
{
    /// <summary>加密 key</summary>
    [JsonPropertyName("encrypt_key")] public string? EncryptKey { get; set; }

    /// <summary>key 版本</summary>
    [JsonPropertyName("version")] public int Version { get; set; }

    /// <summary>剩余有效时间（秒）</summary>
    [JsonPropertyName("expire_in")] public int ExpireIn { get; set; }

    /// <summary>加密 iv</summary>
    [JsonPropertyName("iv")] public string? Iv { get; set; }

    /// <summary>创建 key 的时间戳</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }
}


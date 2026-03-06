using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>客服账号信息</summary>
public class KfAccount
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>客服名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>客服头像 URL</summary>
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }
}


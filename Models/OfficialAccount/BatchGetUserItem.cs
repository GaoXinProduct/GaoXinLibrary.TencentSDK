using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>批量获取用户 — 单项</summary>
public class BatchGetUserItem
{
    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }

    /// <summary>语言（zh_CN/zh_TW/en），默认 zh_CN</summary>
    [JsonPropertyName("lang")] public string? Lang { get; set; }
}


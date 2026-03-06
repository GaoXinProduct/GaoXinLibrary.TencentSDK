using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>模板消息跳小程序</summary>
public class TemplateMiniProgram
{
    /// <summary>小程序 AppId</summary>
    [JsonPropertyName("appid")] public required string AppId { get; set; }

    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}


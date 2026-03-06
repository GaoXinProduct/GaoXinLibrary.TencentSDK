using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台功能按钮</summary>
public class WorkbenchButton
{
    /// <summary>按钮文字</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;

    /// <summary>点击后跳转的 URL</summary>
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }

    /// <summary>小程序 appid</summary>
    [JsonPropertyName("miniprogram_appid")] public string? MiniProgramAppId { get; set; }

    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("miniprogram_pagepath")] public string? MiniProgramPagePath { get; set; }
}


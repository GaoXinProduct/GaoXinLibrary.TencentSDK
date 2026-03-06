using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台列表项</summary>
public class WorkbenchListItem
{
    /// <summary>列表项标题</summary>
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;

    /// <summary>点击后跳转的 URL</summary>
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }

    /// <summary>点击后跳转的小程序 appid</summary>
    [JsonPropertyName("miniprogram_appid")] public string? MiniProgramAppId { get; set; }

    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("miniprogram_pagepath")] public string? MiniProgramPagePath { get; set; }
}


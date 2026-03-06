using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

/// <summary>工作台关键数据项</summary>
public class WorkbenchKeyDataItem
{
    /// <summary>关键数据名称</summary>
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;

    /// <summary>关键数据值</summary>
    [JsonPropertyName("data")] public string Data { get; set; } = string.Empty;

    /// <summary>点击后跳转的 URL</summary>
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }

    /// <summary>小程序 appid</summary>
    [JsonPropertyName("miniprogram_appid")] public string? MiniProgramAppId { get; set; }

    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("miniprogram_pagepath")] public string? MiniProgramPagePath { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>菜单-点击</summary>
public class KfMenuClick
{
    /// <summary>菜单 id</summary>
    [JsonPropertyName("id")] public string? Id { get; set; }

    /// <summary>菜单内容</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }
}


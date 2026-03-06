using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>汇报人</summary>
public class Reporter
{
    /// <summary>汇报人 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}


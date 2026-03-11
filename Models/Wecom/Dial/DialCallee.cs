using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

/// <summary>被拨打者</summary>
public class DialCallee
{
    /// <summary>被拨打的号码</summary>
    [JsonPropertyName("phone")] public string? Phone { get; set; }

    /// <summary>通话时长（秒）</summary>
    [JsonPropertyName("duration")] public int Duration { get; set; }
}


namespace GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

/// <summary>拨出者</summary>
public sealed class DialCaller
{
    /// <summary>拨出者userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>通话时长（秒）</summary>
    [JsonPropertyName("duration")] public int Duration { get; set; }
}

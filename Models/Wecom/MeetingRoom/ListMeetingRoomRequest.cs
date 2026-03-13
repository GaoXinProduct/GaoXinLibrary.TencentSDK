using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>查询会议室列表请求</summary>
public class ListMeetingRoomRequest
{
    /// <summary>城市</summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>楼宇</summary>
    [JsonPropertyName("building")]
    public string? Building { get; set; }

    /// <summary>楼层</summary>
    [JsonPropertyName("floor")]
    public string? Floor { get; set; }

    /// <summary>设备</summary>
    [JsonPropertyName("equipment")]
    public int? Equipment { get; set; }
}

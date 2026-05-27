using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取直播观看明细响应</summary>
public class GetLivingWatchDetailResponse : WecomBaseResponse
{
    /// <summary>观众观看明细列表</summary>
    [JsonPropertyName("watch_info")]
    public LivingWatchInfo[]? WatchInfo { get; set; }

    /// <summary>翻页查询的游标（下次查询时传入）</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

/// <summary>观众观看明细</summary>
public class LivingWatchInfo
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>观看时长（秒）</summary>
    [JsonPropertyName("watch_time")]
    public int WatchTime { get; set; }

    /// <summary>进入直播间时间（Unix 时间戳）</summary>
    [JsonPropertyName("enter_time")]
    public long EnterTime { get; set; }

    /// <summary>离开直播间时间（Unix 时间戳）</summary>
    [JsonPropertyName("leave_time")]
    public long LeaveTime { get; set; }

    /// <summary>观看时长（单位：秒）</summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}
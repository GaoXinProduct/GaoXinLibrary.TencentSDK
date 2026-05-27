using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

/// <summary>
/// 获取客户朋友圈全部发表记录请求
/// </summary>
public record GetMomentsTasksRequest
{
    /// <summary>朋友圈记录开始时间（Unix时间戳）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>朋友圈记录结束时间（Unix时间戳）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>朋友圈创建人userid</summary>
    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    /// <summary>朋友圈类型：0-企业发表 1-个人发表 2-所有</summary>
    [JsonPropertyName("filter_type")]
    public int? FilterType { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>返回的最大记录数（最大值20）</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
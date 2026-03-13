using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取联系客户统计数据请求</summary>
public class GetUserBehaviorDataRequest
{
    /// <summary>成员 userid 列表</summary>
    [JsonPropertyName("userid")]
    public string[] UserIdList { get; set; } = [];

    /// <summary>起始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }
}

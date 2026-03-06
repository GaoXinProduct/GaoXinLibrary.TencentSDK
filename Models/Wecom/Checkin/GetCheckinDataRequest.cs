using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取打卡记录数据请求</summary>
public class GetCheckinDataRequest
{
    /// <summary>打卡类型：1-上下班打卡 2-外出打卡 3-全部打卡</summary>
    [JsonPropertyName("opencheckindatatype")] public int OpenCheckinDataType { get; set; }

    /// <summary>获取打卡记录的开始时间（Unix 时间戳）</summary>
    [JsonPropertyName("starttime")] public long StartTime { get; set; }

    /// <summary>获取打卡记录的结束时间（Unix 时间戳）</summary>
    [JsonPropertyName("endtime")] public long EndTime { get; set; }

    /// <summary>需要获取打卡记录的用户列表</summary>
    [JsonPropertyName("useridlist")] public string[] UserIdList { get; set; } = [];
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>获取打卡月报数据响应</summary>
public class GetCheckinMonthDataResponse : WecomBaseResponse
{
    /// <summary>月报数据列表</summary>
    [JsonPropertyName("datas")] public CheckinMonthDataItem[]? Datas { get; set; }
}


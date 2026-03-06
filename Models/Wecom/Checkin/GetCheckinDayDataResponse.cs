using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>获取打卡日报数据响应</summary>
public class GetCheckinDayDataResponse : WecomBaseResponse
{
    /// <summary>日报数据列表</summary>
    [JsonPropertyName("datas")] public CheckinDayDataItem[]? Datas { get; set; }
}


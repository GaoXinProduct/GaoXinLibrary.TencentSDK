using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>获取打卡记录数据响应</summary>
public sealed class GetCheckinDataResponse : WecomBaseResponse
{
    /// <summary>打卡记录列表</summary>
    [JsonPropertyName("checkindata")] public CheckinDataItem[]? CheckinData { get; set; }
}


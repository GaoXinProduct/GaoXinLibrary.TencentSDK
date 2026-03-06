using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>获取员工打卡规则响应</summary>
public class GetCheckinOptionResponse : WecomBaseResponse
{
    /// <summary>打卡规则列表</summary>
    [JsonPropertyName("info")] public CheckinOptionInfo[]? Info { get; set; }
}


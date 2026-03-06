using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>接口调用额度详情</summary>
public class ApiQuotaDetail
{
    /// <summary>当天该账号可调用该接口的次数</summary>
    [JsonPropertyName("daily_limit")] public long DailyLimit { get; set; }
    /// <summary>当天已经调用的次数</summary>
    [JsonPropertyName("used")] public long Used { get; set; }
    /// <summary>当天剩余调用次数</summary>
    [JsonPropertyName("remain")] public long Remain { get; set; }
}


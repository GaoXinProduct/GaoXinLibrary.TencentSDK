using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>API 调用额度详情</summary>
public sealed class OfficialApiQuotaInfo
{
    [JsonPropertyName("daily_limit")] public long DailyLimit { get; set; }
    [JsonPropertyName("used")] public long Used { get; set; }
    [JsonPropertyName("remain")] public long Remain { get; set; }
}


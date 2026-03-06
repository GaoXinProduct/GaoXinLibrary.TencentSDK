using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取用户安全等级响应</summary>
public class GetUserRiskRankResponse : WechatBaseResponse
{
    /// <summary>用户风险等级（0~4，0 为风险最低）</summary>
    [JsonPropertyName("risk_rank")] public int RiskRank { get; set; }
    /// <summary>唯一请求标识</summary>
    [JsonPropertyName("unoin_id")] public long UnoinId { get; set; }
}


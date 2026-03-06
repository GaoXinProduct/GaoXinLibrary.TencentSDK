using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>接待人员明细统计数据详情</summary>
public class KfServicerStatData
{
    /// <summary>咨询会话数</summary>
    [JsonPropertyName("session_cnt")] public int SessionCnt { get; set; }

    /// <summary>咨询客户数</summary>
    [JsonPropertyName("customer_cnt")] public int CustomerCnt { get; set; }

    /// <summary>咨询消息总数</summary>
    [JsonPropertyName("customer_msg_cnt")] public int CustomerMsgCnt { get; set; }

    /// <summary>人工回复率</summary>
    [JsonPropertyName("reply_rate")] public double ReplyRate { get; set; }

    /// <summary>首次响应平均时长（秒）</summary>
    [JsonPropertyName("first_reply_average_sec")] public double FirstReplyAverageSec { get; set; }

    /// <summary>满意度评价发送数</summary>
    [JsonPropertyName("satisfaction_investgate_cnt")] public int SatisfactionInvestgateCnt { get; set; }

    /// <summary>满意度参评率</summary>
    [JsonPropertyName("satisfaction_participation_rate")] public double SatisfactionParticipationRate { get; set; }

    /// <summary>"满意"评价占比</summary>
    [JsonPropertyName("satisfied_rate")] public double SatisfiedRate { get; set; }

    /// <summary>"一般"评价占比</summary>
    [JsonPropertyName("middling_rate")] public double MiddlingRate { get; set; }

    /// <summary>"不满意"评价占比</summary>
    [JsonPropertyName("dissatisfied_rate")] public double DissatisfiedRate { get; set; }

    /// <summary>升级服务客户数</summary>
    [JsonPropertyName("upgrade_service_customer_cnt")] public int UpgradeServiceCustomerCnt { get; set; }

    /// <summary>升级服务会话数</summary>
    [JsonPropertyName("upgrade_service_member_invite_cnt")] public int UpgradeServiceMemberInviteCnt { get; set; }

    /// <summary>被拒收消息的客户数</summary>
    [JsonPropertyName("msg_rejected_customer_cnt")] public int MsgRejectedCustomerCnt { get; set; }
}


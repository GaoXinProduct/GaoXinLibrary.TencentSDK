using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>企业汇总统计数据详情</summary>
public class KfCorpStatData
{
    /// <summary>咨询会话数</summary>
    [JsonPropertyName("session_cnt")] public int SessionCnt { get; set; }

    /// <summary>咨询客户数</summary>
    [JsonPropertyName("customer_cnt")] public int CustomerCnt { get; set; }

    /// <summary>咨询消息总数</summary>
    [JsonPropertyName("customer_msg_cnt")] public int CustomerMsgCnt { get; set; }

    /// <summary>升级服务客户数</summary>
    [JsonPropertyName("upgrade_service_customer_cnt")] public int UpgradeServiceCustomerCnt { get; set; }

    /// <summary>智能回复会话数</summary>
    [JsonPropertyName("ai_session_reply_cnt")] public int AiSessionReplyCnt { get; set; }

    /// <summary>转人工会话数</summary>
    [JsonPropertyName("ai_transfer_session_cnt")] public int AiTransferSessionCnt { get; set; }

    /// <summary>知识命中会话数</summary>
    [JsonPropertyName("ai_knowledge_hit_session_cnt")] public int AiKnowledgeHitSessionCnt { get; set; }

    /// <summary>被拒收消息的客户数</summary>
    [JsonPropertyName("msg_rejected_customer_cnt")] public int MsgRejectedCustomerCnt { get; set; }
}


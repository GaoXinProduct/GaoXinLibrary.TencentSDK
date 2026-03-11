using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>客户联系行为数据</summary>
public class UserBehaviorData
{
    /// <summary>统计时间戳</summary>
    [JsonPropertyName("stat_time")] public long StatTime { get; set; }

    /// <summary>发起申请数</summary>
    [JsonPropertyName("new_apply_cnt")] public int NewApplyCnt { get; set; }

    /// <summary>新增客户数</summary>
    [JsonPropertyName("new_contact_cnt")] public int NewContactCnt { get; set; }

    /// <summary>聊天总数</summary>
    [JsonPropertyName("chat_cnt")] public int ChatCnt { get; set; }

    /// <summary>发送消息数</summary>
    [JsonPropertyName("message_cnt")] public int MessageCnt { get; set; }

    /// <summary>已回复聊天占比</summary>
    [JsonPropertyName("reply_percentage")] public double ReplyPercentage { get; set; }

    /// <summary>平均首次回复时长（秒）</summary>
    [JsonPropertyName("avg_reply_time")] public int AvgReplyTime { get; set; }

    /// <summary>删除/拉黑成员的客户数</summary>
    [JsonPropertyName("negative_feedback_cnt")] public int NegativeFeedbackCnt { get; set; }
}

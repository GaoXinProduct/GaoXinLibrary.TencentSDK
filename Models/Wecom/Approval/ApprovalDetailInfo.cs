using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批详情</summary>
public class ApprovalDetailInfo
{
    /// <summary>审批单号</summary>
    [JsonPropertyName("sp_no")] public string? SpNo { get; set; }

    /// <summary>审批模板名称</summary>
    [JsonPropertyName("sp_name")] public string? SpName { get; set; }

    /// <summary>审批单状态：1-审批中 2-已通过 3-已驳回 4-已撤销 6-通过后撤销 7-已删除 10-已支付</summary>
    [JsonPropertyName("sp_status")] public int? SpStatus { get; set; }

    /// <summary>审批模板 id</summary>
    [JsonPropertyName("template_id")] public string? TemplateId { get; set; }

    /// <summary>申请时间（Unix 时间戳）</summary>
    [JsonPropertyName("apply_time")] public long? ApplyTime { get; set; }

    /// <summary>申请人信息</summary>
    [JsonPropertyName("applyer")] public ApprovalApplyer? Applyer { get; set; }

    /// <summary>审批流程信息</summary>
    [JsonPropertyName("sp_record")] public SpRecord[]? SpRecord { get; set; }

    /// <summary>抄送信息</summary>
    [JsonPropertyName("notifyer")] public ApprovalNotifyer[]? Notifyer { get; set; }

    /// <summary>审批申请数据</summary>
    [JsonPropertyName("apply_data")] public ApplyData? ApplyData { get; set; }

    /// <summary>审批申请备注信息</summary>
    [JsonPropertyName("comments")] public ApprovalComment[]? Comments { get; set; }
}


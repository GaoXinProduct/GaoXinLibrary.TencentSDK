using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>提交审批申请请求</summary>
public class ApplyEventRequest
{
    /// <summary>申请人 userid</summary>
    [JsonPropertyName("creator_userid")] public string CreatorUserId { get; set; } = string.Empty;

    /// <summary>模板 id</summary>
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;

    /// <summary>审批人模式：0-通过接口指定审批人 1-使用此模板在管理后台设置的审批流程</summary>
    [JsonPropertyName("use_template_approver")] public int UseTemplateApprover { get; set; }

    /// <summary>抄送方式：1-提单时 2-单据通过后 3-提单和通过后</summary>
    [JsonPropertyName("choose_department")] public long? ChooseDepartment { get; set; }

    /// <summary>审批人列表（当 use_template_approver = 0 时必填）</summary>
    [JsonPropertyName("approver")] public ApprovalApprover[]? Approver { get; set; }

    /// <summary>抄送人列表</summary>
    [JsonPropertyName("notifyer")] public string[]? Notifyer { get; set; }

    /// <summary>抄送方式：1-提单时 2-单据通过后 3-提单和通过后</summary>
    [JsonPropertyName("notify_type")] public int? NotifyType { get; set; }

    /// <summary>审批申请数据</summary>
    [JsonPropertyName("apply_data")] public ApplyData ApplyData { get; set; } = new();

    /// <summary>摘要信息（最多3行，每行最多20个字符）</summary>
    [JsonPropertyName("summary_list")] public ApprovalSummary[]? SummaryList { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批备注</summary>
public class ApprovalComment
{
    /// <summary>备注人信息</summary>
    [JsonPropertyName("commentUserInfo")] public ApprovalApplyerInfo? CommentUserInfo { get; set; }

    /// <summary>备注提交时间（Unix 时间戳）</summary>
    [JsonPropertyName("commenttime")] public long? CommentTime { get; set; }

    /// <summary>备注内容</summary>
    [JsonPropertyName("commentcontent")] public string? CommentContent { get; set; }

    /// <summary>备注 id</summary>
    [JsonPropertyName("commentid")] public string? CommentId { get; set; }
}


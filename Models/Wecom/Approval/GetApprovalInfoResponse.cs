using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>批量获取审批单号响应</summary>
public class GetApprovalInfoResponse : WecomBaseResponse
{
    /// <summary>审批单号列表</summary>
    [JsonPropertyName("sp_no_list")] public string[]? SpNoList { get; set; }

    /// <summary>下一个游标</summary>
    [JsonPropertyName("new_next_cursor")] public int? NewNextCursor { get; set; }
}


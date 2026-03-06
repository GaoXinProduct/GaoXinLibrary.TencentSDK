using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>获取审批数据（旧）响应</summary>
public class GetApprovalDataResponse : WecomBaseResponse
{
    /// <summary>审批数据总数</summary>
    [JsonPropertyName("count")] public int Count { get; set; }

    /// <summary>审批数据总条数（可能大于 count）</summary>
    [JsonPropertyName("total")] public int Total { get; set; }

    /// <summary>下次分页请求起始位置</summary>
    [JsonPropertyName("next_spnum")] public long? NextSpNum { get; set; }

    /// <summary>审批数据列表</summary>
    [JsonPropertyName("data")] public ApprovalDataItem[]? Data { get; set; }
}


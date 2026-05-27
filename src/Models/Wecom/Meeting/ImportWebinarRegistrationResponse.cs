using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>导入网络研讨会报名信息响应</summary>
/// <remarks>doc path: /98880</remarks>
public class ImportWebinarRegistrationResponse : WecomBaseResponse
{
    /// <summary>成功导入数量</summary>
    [JsonPropertyName("success_count")]
    public int SuccessCount { get; set; }

    /// <summary>失败数量</summary>
    [JsonPropertyName("fail_count")]
    public int FailCount { get; set; }

    /// <summary>失败详情列表</summary>
    [JsonPropertyName("fail_list")]
    public List<ImportFailItem>? FailList { get; set; }
}
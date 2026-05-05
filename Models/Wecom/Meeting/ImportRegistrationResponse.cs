using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>导入会议报名信息响应</summary>
/// <remarks>doc path: /98816</remarks>
public class ImportRegistrationResponse : WecomBaseResponse
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

/// <summary>导入失败项</summary>
public class ImportFailItem
{
    /// <summary>报名人名称</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>失败原因</summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}
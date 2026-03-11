using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表详情响应</summary>
public class GetCollectFormResponse : WecomBaseResponse
{
    /// <summary>收集表信息</summary>
    [JsonPropertyName("form_info")] public CollectFormInfo? FormInfo { get; set; }
}

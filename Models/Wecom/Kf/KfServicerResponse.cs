using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>添加/删除接待人员响应</summary>
public sealed class KfServicerResponse : WecomBaseResponse
{
    /// <summary>操作结果列表</summary>
    [JsonPropertyName("result_list")] public KfServicerResult[]? ResultList { get; set; }
}


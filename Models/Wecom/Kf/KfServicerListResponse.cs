using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取接待人员列表响应</summary>
public class KfServicerListResponse : WecomBaseResponse
{
    /// <summary>接待人员列表</summary>
    [JsonPropertyName("servicer_list")] public KfServicer[]? ServicerList { get; set; }
}


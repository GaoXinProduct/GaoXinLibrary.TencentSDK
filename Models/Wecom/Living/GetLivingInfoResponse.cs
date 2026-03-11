using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取直播详情响应</summary>
public class GetLivingInfoResponse : WecomBaseResponse
{
    /// <summary>直播信息</summary>
    [JsonPropertyName("living_info")] public LivingInfo? LivingInfo { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取会话状态响应</summary>
public class KfServiceStateGetResponse : WecomBaseResponse
{
    /// <summary>当前的会话状态：0-未处理 1-由智能助手接待 2-待接入池等待 3-人工接待中 4-已结束/未开始</summary>
    [JsonPropertyName("service_state")] public int ServiceState { get; set; }

    /// <summary>接待人员的 userid（仅 service_state=3 时返回）</summary>
    [JsonPropertyName("servicer_userid")] public string? ServicerUserId { get; set; }
}


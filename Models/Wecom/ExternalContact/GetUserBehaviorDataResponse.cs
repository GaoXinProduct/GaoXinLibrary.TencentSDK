using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>客户联系统计数据响应</summary>
public class GetUserBehaviorDataResponse : WecomBaseResponse
{
    /// <summary>行为数据列表</summary>
    [JsonPropertyName("behavior_data")] public UserBehaviorData[]? BehaviorData { get; set; }
}

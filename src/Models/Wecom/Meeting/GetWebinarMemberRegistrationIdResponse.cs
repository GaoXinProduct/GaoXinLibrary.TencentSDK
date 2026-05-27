using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会成员报名ID响应</summary>
/// <remarks>doc path: /98873</remarks>
public class GetWebinarMemberRegistrationIdResponse : WecomBaseResponse
{
    /// <summary>报名ID</summary>
    [JsonPropertyName("registration_id")]
    public string? RegistrationId { get; set; }
}
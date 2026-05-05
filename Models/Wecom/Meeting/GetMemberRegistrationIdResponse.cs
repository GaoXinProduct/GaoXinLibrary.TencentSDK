using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议成员报名ID响应</summary>
/// <remarks>doc path: /98794</remarks>
public class GetMemberRegistrationIdResponse : WecomBaseResponse
{
    /// <summary>报名ID</summary>
    [JsonPropertyName("registration_id")]
    public string? RegistrationId { get; set; }
}
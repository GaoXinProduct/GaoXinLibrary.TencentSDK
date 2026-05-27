using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室应答状态响应</summary>
/// <remarks>doc path: /98806</remarks>
public class GetRoomsAnswerStatusResponse : WecomBaseResponse
{
    /// <summary>应答状态：0-未知，1-已接听，2-未接听，3-拒绝，4-超时</summary>
    [JsonPropertyName("answer_status")]
    public int AnswerStatus { get; set; }
}
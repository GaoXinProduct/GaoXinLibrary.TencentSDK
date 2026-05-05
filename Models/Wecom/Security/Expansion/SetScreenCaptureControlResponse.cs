using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security.Expansion;

public class SetScreenCaptureControlResponse : WecomBaseResponse
{
    [JsonPropertyName("control_type")]
    public int ControlType { get; set; }
}
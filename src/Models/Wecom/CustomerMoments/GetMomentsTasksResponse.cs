using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

public class GetMomentsTasksResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("moment_list")]
    public MomentsTaskInfo[]? MomentList { get; set; }
}
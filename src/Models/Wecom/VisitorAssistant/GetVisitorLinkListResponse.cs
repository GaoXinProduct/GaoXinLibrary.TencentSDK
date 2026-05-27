using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public class GetVisitorLinkListResponse : WecomBaseResponse
{
    [JsonPropertyName("link_id_list")]
    public string[]? LinkIdList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}
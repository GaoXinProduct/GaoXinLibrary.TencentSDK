using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

public class GetTagListResponse : WecomBaseResponse
{
    [JsonPropertyName("taglist")] public TagInfo[]? TagList { get; set; }
}


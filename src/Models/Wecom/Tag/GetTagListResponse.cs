using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

public sealed class GetTagListResponse : WecomBaseResponse
{
    [JsonPropertyName("taglist")] public TagInfo[]? TagList { get; set; }
}


using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取视图列表响应</summary>
public sealed class GetViewsResponse : WecomBaseResponse
{
    /// <summary>视图列表</summary>
    [JsonPropertyName("views")] public SheetView[]? Views { get; set; }

    /// <summary>符合筛选条件的视图总数。</summary>
    [JsonPropertyName("total")] public uint Total { get; set; }

    /// <summary>是否还有下一页。</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>下一页的查询偏移量。</summary>
    [JsonPropertyName("next")] public uint NextOffset { get; set; }
}

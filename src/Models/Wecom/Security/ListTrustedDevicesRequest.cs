namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>设备列表查询条件。</summary>
public sealed class ListTrustedDevicesRequest
{
    /// <summary>要查询的设备类型。</summary>
    [JsonPropertyName("type")] public required int Type { get; init; }

    /// <summary>上一页返回的游标，首页留空。</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }

    /// <summary>本页返回数量上限。</summary>
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

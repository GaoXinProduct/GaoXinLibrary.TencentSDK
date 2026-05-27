using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询门店列表请求（POST /cgi-bin/poi/getpoilist）</summary>
public sealed class GetPoiListRequest
{
    [JsonPropertyName("begin")] public int Begin { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; } = 20;
}


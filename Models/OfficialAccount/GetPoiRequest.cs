using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询门店信息请求（POST /cgi-bin/poi/getpoi）</summary>
public class GetPoiRequest
{
    [JsonPropertyName("poi_id")] public required string PoiId { get; set; }
}


using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除门店请求（POST /cgi-bin/poi/delpoi）</summary>
public sealed class DeletePoiRequest
{
    [JsonPropertyName("poi_id")] public required string PoiId { get; set; }
}


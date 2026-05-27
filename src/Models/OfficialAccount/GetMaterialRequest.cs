using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取永久素材请求（POST /cgi-bin/material/get_material）</summary>
public sealed class GetMaterialRequest
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
}


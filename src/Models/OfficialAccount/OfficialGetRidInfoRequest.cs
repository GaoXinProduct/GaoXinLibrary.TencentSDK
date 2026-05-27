using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询 rid 信息请求（POST /cgi-bin/openapi/rid/get）</summary>
public sealed class OfficialGetRidInfoRequest
{
    [JsonPropertyName("rid")] public required string Rid { get; set; }
}


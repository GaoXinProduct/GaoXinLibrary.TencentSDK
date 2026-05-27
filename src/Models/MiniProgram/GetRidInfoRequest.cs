using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询 rid 信息请求（POST /cgi-bin/openapi/rid/get）
/// </summary>
public sealed class GetRidInfoRequest
{
    /// <summary>调用接口报错返回的 rid</summary>
    [JsonPropertyName("rid")] public required string Rid { get; set; }
}


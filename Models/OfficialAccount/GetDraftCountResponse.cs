using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取草稿总数响应（GET /cgi-bin/draft/count）</summary>
public sealed class GetDraftCountResponse : WechatBaseResponse
{
    [JsonPropertyName("total_count")] public int TotalCount { get; set; }
}


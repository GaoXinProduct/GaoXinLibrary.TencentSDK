using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>新建草稿响应</summary>
public sealed class AddDraftResponse : WechatBaseResponse
{
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
}


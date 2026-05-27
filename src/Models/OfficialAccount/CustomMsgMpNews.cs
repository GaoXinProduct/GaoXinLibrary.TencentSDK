using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图文消息（点击跳转到图文消息页面）</summary>
public sealed class CustomMsgMpNews { [JsonPropertyName("media_id")] public required string MediaId { get; set; } }


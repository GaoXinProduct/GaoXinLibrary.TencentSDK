namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>微信客服有新消息或事件的通知</summary>
public sealed class KfMessageOrEventCallback : CallbackEventBase
{
    /// <summary>读取客服消息时使用的回调 Token</summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>有新消息或事件的客服账号 ID</summary>
    public string OpenKfId { get; set; } = string.Empty;
}

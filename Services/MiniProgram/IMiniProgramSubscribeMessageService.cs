using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序订阅消息服务接口
/// </summary>
public interface IMiniProgramSubscribeMessageService
{
    /// <summary>
    /// 发送订阅消息（subscribeMessage.send）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<SendSubscribeMessageResponse> SendAsync(SendSubscribeMessageRequest request, CancellationToken ct = default);
}

